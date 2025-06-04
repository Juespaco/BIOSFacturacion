using GrupoBIOS.Application.DTOs;

namespace GrupoBIOS.Presentation.WebUI.Service.Nivel
{
    public interface INivelService
    {
        Task<string> Register(List<NivelDTO> register);
    }
}
