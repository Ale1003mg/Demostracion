namespace Demo.View.Mate.Installer
{
    public class AddcontrolHttp:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();
            services.AddControllersWithViews();
        }
    }
}
