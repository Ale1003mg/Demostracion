namespace Demo.apidat.Installer
{
    public class AddEndpointsApi : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();
        }
    }
}
