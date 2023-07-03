namespace Demo.Apigate.Installer
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection service, IConfiguration configuration)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
            typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();

            installers.ForEach(installers => installers.InstallServices(service, configuration));
        }
    }
}
