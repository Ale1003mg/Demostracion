namespace Demo.View.Mate.Config
{
    public interface IConfigure
    {
        void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
