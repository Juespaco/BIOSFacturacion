using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface ICompaniaApplication : IApplication<CompaniaDTO>
    {
        Task<Response<bool>> DesactivarCompania(int IDCompania);

        Task<Response<ConfiguracionCompaniaDTO>> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa);

        Task<Response<string>> ConfigurationAsync(ConfiguracionCompaniaDTO modelDto);
    }
}
