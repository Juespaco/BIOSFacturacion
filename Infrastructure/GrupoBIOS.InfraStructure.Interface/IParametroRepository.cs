using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IParametroRepository : IRepository<Parametro>
    {
        Task<IEnumerable<Parametro>> GetParametroClase(int IDClase);
        Task<string> DesactivarParametro(int IDParametro);
    }
}
