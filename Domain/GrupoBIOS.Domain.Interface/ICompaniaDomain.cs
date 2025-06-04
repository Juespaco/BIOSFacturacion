using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.Domain.Interface
{
    public interface ICompaniaDomain : IDomain<Compania>
    {
        Task<bool> DesactivarCompania(int IDCompania);

        Task<ConfiguracionCompania> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa);

        Task<string> CompanyConfigurationAsync(ConfiguracionCompania model);
    }
}
