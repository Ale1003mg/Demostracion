using Demo.apidat.dao.dao;

namespace Demo.apidat.Installer
{
    public class Trasaction:IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDao_Usuarios, Dao_Usuarios>();
        }
    }
}
