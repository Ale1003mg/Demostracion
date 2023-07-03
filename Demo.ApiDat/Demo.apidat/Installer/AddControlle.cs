namespace Demo.apidat.Installer
{
    public class AddControlle:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers(); ;
        }
    }
}
