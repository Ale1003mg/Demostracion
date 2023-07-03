using Demo.View.Mate.Proxys;

namespace Demo.View.Mate.Installer
{
    public class HttpCLiente:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<IP_Usuarios, P_Usuarios>();
        }
    }
}
