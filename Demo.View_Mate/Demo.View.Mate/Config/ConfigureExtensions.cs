namespace Demo.View.Mate.Config
{
    public static class ConfigureExtensions
    {
        public static void InstallConfigurationsInAssembly(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            var installers = typeof(Program).Assembly.ExportedTypes.Where(x =>
            typeof(IConfigure).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IConfigure>().ToList();

            installers.ForEach(installers => installers.InstallConfigures(app, env));
        }
    }
}
