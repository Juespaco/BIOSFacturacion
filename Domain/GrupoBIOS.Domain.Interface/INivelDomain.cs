using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Interface
{
    public interface INivelDomain
    {
        Task<string> CrearActualizarNivelesAsync(IEnumerable<Nivel> niveles);
    }

}
