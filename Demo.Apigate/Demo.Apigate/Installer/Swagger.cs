using Demo.Apigate.Common;
using Microsoft.OpenApi.Models;

namespace Demo.Apigate.Installer
{
    public class Swagger:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen();
            //Swagger
            var xmlFile = "api.dat.controlproyectos.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            CreateXml DocXml = new();
            DocXml.Xml(xmlPath);

            services.AddSwaggerGen(doc =>
            {
                doc.EnableAnnotations();
                doc.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Demos.apigate",
                    Description = "API de servicios de Gateway",
                    TermsOfService = new Uri("https://policies.google.com/terms?hl=en-US"),
                    //Contact = new OpenApiContact
                    //{
                    //    Name = "Contacto de soporte a integraciones",
                    //    Email = "integration_support_contact@isystemcorp.io",
                    //    Url = new Uri("https://about.google/contact-google/?hl=es"),
                    //},
                    //License = new OpenApiLicense
                    //{
                    //    Name = "Licencia LICX",
                    //    Url = new Uri("https://opensource.google/documentation/reference/thirdparty/licenses"),
                    //}
                });
                doc.IncludeXmlComments(xmlPath);
                //TODO: Activar la sección de configuración.
                //doc.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                //{
                //    In = ParameterLocation.Header,
                //    Description = "Copy and paste the Token in the 'Value:' field like this: Bearer {Token JWT}.",
                //    Name = "Authorization",
                //    Type = SecuritySchemeType.ApiKey
                //});
                //doc.AddSecurityRequirement(new OpenApiSecurityRequirement
                //            {
                //              {
                //                new OpenApiSecurityScheme
                //                {
                //                   Reference = new OpenApiReference
                //                   {
                //                     Type = ReferenceType.SecurityScheme,
                //                     Id = "Bearer"
                //                   }
                //                 },
                //                 new string[] { }
                //              }
                //            });
            });
        }
    }
}
