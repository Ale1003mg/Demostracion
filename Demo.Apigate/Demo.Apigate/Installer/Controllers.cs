namespace Demo.Apigate.Installer
{
    public class Controllers: IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
        }
    }
}
