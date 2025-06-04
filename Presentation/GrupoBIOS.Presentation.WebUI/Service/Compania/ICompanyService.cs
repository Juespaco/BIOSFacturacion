using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Presentation.WebUI.Service.Compania
{
    public interface ICompanyService
    {
        Task<string> Register(CompaniaDTO register);
        Task<Response<IEnumerable<CompaniaDTO>>> GetListCompanias();
        Task<Response<CompaniaDTO>> GetCompaniaId(int IDCompania);
        Task<Response<ConfiguracionCompaniaDTO>> GetConfiguracionCompaniaId(int IDCompania);
        Task<Response<bool>> DesactivarCompania(int IDCompania);        
        Task<string?> UpdateCompaniaAsync(CompaniaDTO register);
    }
}
