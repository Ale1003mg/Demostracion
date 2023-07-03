namespace Demo.Apigate.Configure
{
    public interface IConfigure
    {
        void InstallConfigures(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
