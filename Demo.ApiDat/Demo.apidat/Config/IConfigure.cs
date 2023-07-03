namespace Demo.apidat.Config
{
    public interface IConfigure
    {
        void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
