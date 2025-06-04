using GrupoBIOS.Domain.Entity;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IExcepcionRepository
    {
        Task<string> CrearActualizarExcepcionesAsync(IEnumerable<Excepcion> excepciones);
    }
}
