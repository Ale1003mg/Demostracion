namespace Demo.ApiOcelot.Config
{
    public class SwaggerConfig:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
               
            }
        }
    }
}
