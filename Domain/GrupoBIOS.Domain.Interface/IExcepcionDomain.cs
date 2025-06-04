using GrupoBIOS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Interface
{
    public interface IExcepcionDomain 
    {
        Task<string> CrearActualizarExcepcionesAsync(IEnumerable<Excepcion> model);
    }
}
