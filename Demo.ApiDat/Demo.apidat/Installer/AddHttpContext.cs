namespace Demo.apidat.Installer
{
    public class AddHttpContext:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
        }
    }
}
