using Demo.Apigate.Common;
using Demo.Apigate.Config;
using Demo.Apigate.Configure;
using Demo.Apigate.Installer;
using Microsoft.OpenApi.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
       
        builder.Services.AddAppsettingBinding(builder.Configuration)
                        .AddProxiesRegistration(builder.Configuration);


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
        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo.Apigate v1"));
        //}

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}