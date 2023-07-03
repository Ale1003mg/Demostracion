namespace Demo.apidat.Config
{
    public class Authorization : IConfigure
    {
        public void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseAuthorization();

           
        }
    }
}
