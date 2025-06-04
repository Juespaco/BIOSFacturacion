using GrupoBIOS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface ICentroOperativoRepository : IRepository<CentroOperativo>
    {
        Task<bool> DesactivarCentroOperativo(int IDCentroOperativo);
        Task<string> CrearActualizarCentroOperativoAsync(IEnumerable<CentroOperativo> centros);
    }
}
