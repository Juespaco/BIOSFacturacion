using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IExcepcionApplication
    {
        Task<Response<string>> CrearActualizarExcepcionesAsync(IEnumerable<ExcepcionDTO> modelDtos);
    }
}
