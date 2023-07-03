namespace Demo.apidat.Config
{
    public class Swagger: IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
           
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                //app.UseSwaggerUI();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "demo.ApiDat v1"));


        }
    }
}
