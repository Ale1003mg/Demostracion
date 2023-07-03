namespace Demo.Apigate.Configure
{
    public class Swagger:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo.Apigate v1"));
        }
    }
}
