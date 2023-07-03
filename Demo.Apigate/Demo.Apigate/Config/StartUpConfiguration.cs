using Demo.apigate.dao;
using Demo.apigate.dao.Proxys;

namespace Demo.Apigate.Config
{
    public static class StartUpConfiguration
    {
        public static IServiceCollection AddAppsettingBinding(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<ApiUrls>(opts => configuration.GetSection("ApiUrls").Bind(opts));
            return service;
        }

        public static IServiceCollection AddProxiesRegistration(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHttpContextAccessor();

            service.AddHttpClient<IP_Usuarios, P_Usuarios>();

            return service;
        }
    }
}
