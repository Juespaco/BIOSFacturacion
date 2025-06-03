using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface ICompaniaRepository : IRepository<Compania>
    {
        Task<bool> DesactivarCompania(int IDCompania);
    }
}
