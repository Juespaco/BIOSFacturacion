using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IPncRepository
    {
        Task<string> CrearActualizarPncsAsync(IEnumerable<Pnc> pncs);
    }

}
