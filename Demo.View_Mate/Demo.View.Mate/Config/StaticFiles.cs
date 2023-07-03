namespace Demo.View.Mate.Config
{
    public class StaticFiles:IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseStaticFiles();
        }
    }
}
