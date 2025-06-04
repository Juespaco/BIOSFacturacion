using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface INivelApplication
    {
        Task<Response<string>> CrearActualizarNivelesAsync(IEnumerable<NivelDTO> nivelesDto);
    }

}
