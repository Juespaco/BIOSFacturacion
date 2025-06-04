using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface INivelRepository
    {
        Task<string> CrearActualizarNivelesAsync(IEnumerable<Nivel> niveles);
    }

}
