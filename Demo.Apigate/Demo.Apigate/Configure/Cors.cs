namespace Demo.Apigate.Configure
{
    public class Cors:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors("AllowWebApp");
        }
    }
}
