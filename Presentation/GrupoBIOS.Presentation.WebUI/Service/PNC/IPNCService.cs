using GrupoBIOS.Application.DTOs;

namespace GrupoBIOS.Presentation.WebUI.Service.PNC
{
    public interface IPNCService
    {
        Task<string> Register(List<PncDTO> register);
    }
}
