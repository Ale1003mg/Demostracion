using Demo.apidat.Common;
using Demo.apidat.Config;
using Demo.apidat.dao.dao;
using Demo.apidat.Installer;
using Microsoft.OpenApi.Models;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

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
        //    app.UseDeveloperExceptionPage();
        //    app.UseSwagger();
        //    //app.UseSwaggerUI();
        //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo.ApiDat v1"));
        //}

        //app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    }