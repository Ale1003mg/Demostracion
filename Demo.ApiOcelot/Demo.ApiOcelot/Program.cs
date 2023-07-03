using Demo.ApiOcelot.Config;
using Demo.ApiOcelot.Intasller;
using Microsoft.OpenApi.Models;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

public class Program
{
    private static void Main(string[] args)
    {
        var configuration = new ConfigurationBuilder()
              .AddJsonFile("appsettings.json")
              .Build();

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Demo.ApiOcelot", Version = "v1" });
        });
        builder.Services.AddSwaggerForOcelot(configuration);
        // Add services to the container.
        // ConfigureServices(builder);
        builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
       
        builder.Services.AddOcelot();
        var app = builder.Build();

        Configure(app);
        // Configure the HTTP request pipeline.
      
    }

    public static void ConfigureServices(WebApplicationBuilder builder)
    {
       
        builder.Services.InstallServicesInAssembly(builder.Configuration);
    }

    public static void Configure(WebApplication app)
    {
        app.InstallConfigurationsInAssembly(app.Environment);

        //if (app.Environment.IsDevelopment())
        //{
        //    app.UseSwagger();
        //    app.UseSwaggerUI();
        //}
        app.UseOcelot().Wait();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }



    }