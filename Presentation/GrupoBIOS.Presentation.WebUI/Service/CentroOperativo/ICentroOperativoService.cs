using GrupoBIOS.Application.DTOs;

namespace GrupoBIOS.Presentation.WebUI.Service.CentroOperativo
{
    public interface ICentroOperativoService
    {
        Task<string> Register(List<CentroOperativoDTO> register);
    }
}
