using Microsoft.OpenApi.Models;

namespace Demo.ApiOcelot.Intasller
{
    public class SwaggerInstaller:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.ApiOcelot", Version = "v1" });
            });
        }
    }
}
