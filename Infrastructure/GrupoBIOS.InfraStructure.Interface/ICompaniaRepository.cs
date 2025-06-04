using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface ICompaniaRepository : IRepository<Compania>
    {
        Task<bool> DesactivarCompania(int IDCompania);

        Task<ConfiguracionCompania> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa);

        Task<string> CompanyConfigurationAsync(ConfiguracionCompania model);
    }
}
