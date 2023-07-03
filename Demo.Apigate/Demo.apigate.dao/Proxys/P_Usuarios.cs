using Demo.apigate.dao.Config;
using Demo.apigate.dto.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Demo.apigate.dao.Proxys
{
    public interface IP_Usuarios
    {
        Task<List<Dto_Usuarios>> GetallUsuarios();
        Task<Dto_Usuarios> GetID_Usuario(int id);
        Task<Boolean> Mante(Dto_Usuarios usuario);
    }
    public class P_Usuarios:IP_Usuarios
    {
        private readonly HttpClient _httpClient;
        private readonly ApiUrls _apiUrls;

        public P_Usuarios(HttpClient httpClient, IOptions<ApiUrls> apiUrls, IHttpContextAccessor httpContextAccessor)
        {
            httpClient.AddBearerToken(httpContextAccessor);
            _httpClient = httpClient;
            _apiUrls = apiUrls.Value;
        }

        public async Task<List<Dto_Usuarios>> GetallUsuarios()
        {
            try
            {
                var request = await _httpClient.GetAsync($"{_apiUrls.Pmate}api/Usuarios");
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
                EventLog.WriteEntry("prueba", "(api.Gate.Mante) P_Usuario Getall_Usuario" + ex, EventLogEntryType.Error);
                return null;
                throw;
            }
        
        }

        public async Task<Dto_Usuarios> GetID_Usuario(int id)
        {
            try
            {
                var request = await _httpClient.GetAsync($"{_apiUrls.Pmate}api/Usuarios/{id}");
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
                EventLog.WriteEntry("prueba", "(api.Gate.Mante)  P_Usuario GetID_Usuario" + ex, EventLogEntryType.Error);
                return null;

                throw;
            }
        }

        public async Task<Boolean> Mante(Dto_Usuarios usuario)
        {
            try
            {
                var content = new StringContent(JsonSerializer.Serialize(usuario), Encoding.UTF8, "application/json");
                var request = await _httpClient.PostAsync($"{_apiUrls.Pmate}api/Usuarios", content);
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
                EventLog.WriteEntry("prueba", "(api.Gate.Mante)  P_Usuario Mante_Usuario" + ex, EventLogEntryType.Error);

                return false;
                throw;
            }
        }
    }
}
