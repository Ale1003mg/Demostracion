namespace Demo.ApiOcelot.Config
{
    public class SwaggerForOcelotUIConfig:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseSwaggerForOcelotUI(opt =>
            //{
            //    opt.PathToSwaggerGenerator = "/swagger/docs";
            //});
        }
    }
}
