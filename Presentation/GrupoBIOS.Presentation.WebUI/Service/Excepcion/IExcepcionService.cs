using GrupoBIOS.Application.DTOs;

namespace GrupoBIOS.Presentation.WebUI.Service.Excepcion
{
    public interface IExcepcionService
    {
        Task<string> Register(List<ExcepcionDTO> register);
    }
}
