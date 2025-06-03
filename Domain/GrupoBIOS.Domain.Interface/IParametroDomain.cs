using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.Domain.Interface
{
    public interface IParametroDomain : IDomain<Parametro>
    {
        Task<IEnumerable<Parametro>> GetParametroClase(int IDClase);
        Task<string> DesactivarParametro(int IDParametro);
    }
}
