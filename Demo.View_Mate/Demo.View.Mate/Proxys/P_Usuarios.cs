using Demo.View.Mate.Models;
using System.Diagnostics;
using System.Text.Json;
using System.Text;
using Demo.view_Mante.Dto.Dto;

namespace Demo.View.Mate.Proxys
{
    public interface IP_Usuarios
    {
        Task<List<Dto_Usuarios>> Getall_Usuario();
        Task<Dto_Usuarios> GetID_Usuario_Sistema(int id);

        Task<Boolean> Mante_Usuario_Sistema(Dto_Usuarios dto_Usuarios);
    }
    public class P_Usuarios:IP_Usuarios
    {
        private readonly string _ApiGatewayUrlProxys;
        private readonly HttpClient _httpClient;

        public P_Usuarios(HttpClient httpClient, ApiGatewayUrlProxys apiGatewayUrlProxys, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _ApiGatewayUrlProxys = apiGatewayUrlProxys.Value;


        }

        public async Task<List<Dto_Usuarios>> Getall_Usuario()
        {
            try
            {
                var request = await _httpClient.GetAsync($"{_ApiGatewayUrlProxys}api/Usuarios/");
                request.EnsureSuccessStatusCode();

                return JsonSerializer.Deserialize<List<Dto_Usuarios>>(
                  await request.Content.ReadAsStringAsync(),
                  new JsonSerializerOptions
                  {
                      PropertyNameCaseInsensitive = true
                  }
              );

            }
            catch (Exception ex)
            {
              //  EventLog.WriteEntry("Prueba", "(mvc.views.ManteUsua) P_Usuario  Getall_Usuario" + ex, EventLogEntryType.Error);
                return null;
                throw;
            }
        }


        public async Task<Dto_Usuarios> GetID_Usuario_Sistema(int id)
        {
            try
            {
                var request = await _httpClient.GetAsync($"{_ApiGatewayUrlProxys}api/Usuarios/{id}");
                request.EnsureSuccessStatusCode();

                return JsonSerializer.Deserialize<Dto_Usuarios>(
                  await request.Content.ReadAsStringAsync(),
                  new JsonSerializerOptions
                  {
                      PropertyNameCaseInsensitive = true
                  }
              );

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Prueba", "(mvc.views.ManteUsua) P_Usuario  GetID_Usuario" + ex, EventLogEntryType.Error);
                return null;
                throw;
            }
        }

        public async Task<Boolean> Mante_Usuario_Sistema(Dto_Usuarios dto_Usuarios)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(dto_Usuarios), Encoding.UTF8, "application/json");
                var request = await _httpClient.PostAsync($"{_ApiGatewayUrlProxys}api/Usuarios/", content);
                request.EnsureSuccessStatusCode();

                return JsonSerializer.Deserialize<Boolean>(
                  await request.Content.ReadAsStringAsync(),
                  new JsonSerializerOptions
                  {
                      PropertyNameCaseInsensitive = true
                  }
              );

            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Prueba", "(mvc.views.ManteUsua) P_Usuario Mante_Usuario" + ex, EventLogEntryType.Error);

                return false;
                throw;
            }
        }
    }
}
