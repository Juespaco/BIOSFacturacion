using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Application.Interface
{
    public interface ICentroOperativoApplication: IApplication<CentroOperativoDTO>
    {
        Task<Response<bool>> DesactivarCentroOperativo(int IDCentroOperativo);
        Task<Response<string>> CrearActualizarCentroOperativoAsync(IEnumerable<CentroOperativoDTO> centroOperativoDto);
    }
}
