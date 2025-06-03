using GrupoBIOS.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Interface
{
    public interface ICentroOperativoDomain : IDomain<CentroOperativo>
    {
        Task<bool> DesactivarCentroOperativo(int IDCompania);
    }
}
