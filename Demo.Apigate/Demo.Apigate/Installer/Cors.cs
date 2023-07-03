namespace Demo.Apigate.Installer
{
    public class Cors:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options => options.AddPolicy("AllowWebApp",
                              builder => builder.AllowAnyOrigin()
                                                 .AllowAnyHeader()
                                                 .AllowAnyMethod()));
        }
    }
}
