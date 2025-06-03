using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IClaseRepository : IRepository<Clase>
    {
        Task<string> DesactivarClase(int IDClase);
    }
}
