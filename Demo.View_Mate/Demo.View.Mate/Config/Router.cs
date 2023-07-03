namespace Demo.View.Mate.Config
{
    public class Router:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();
        }
    }
}
