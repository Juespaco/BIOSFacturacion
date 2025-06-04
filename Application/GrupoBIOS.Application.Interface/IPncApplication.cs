using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IPncApplication
    {
        Task<Response<string>> CrearActualizarPncsAsync(IEnumerable<PncDTO> pncsDto);
    }

}
