using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.Domain.Interface
{
    public interface IClaseDomain : IDomain<Clase>
    {
        Task<string> DesactivarClase(int IDClase);
    }
}
