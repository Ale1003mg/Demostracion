using Demo.View.Mate.Config;
using Demo.View.Mate.Installer;
using Demo.View.Mate.Proxys;

namespace Demo.View.Mate
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            
            builder.Services.AddSingleton(new ApiGatewayUrlProxys(builder.Configuration.GetValue<string>("ApiGatewayUrlProxys")));
    
            ConfigureServices(builder);
            var app = builder.Build();

            Configure(app);
        }

        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.InstallServicesInAssembly(builder.Configuration);
        }

        public static void Configure(WebApplication app)
        {
            app.InstallConfigurationsInAssembly(app.Environment);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseAuthorization();

            app.MapControllerRoute(
                   name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

  
}