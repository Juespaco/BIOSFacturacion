using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Response;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Presentation.WebUI.Service.Siesa
{
    public interface ISiesaService
    {
        Task<Response<IEnumerable<CompaniaSiesaResponseDTO>>> GetListCompaniaAsync();
        Task<Response<IEnumerable<CentrosOperativosSiesaResponseDTO>>> GetListCentrosOperativosAsync(int p_cia);
    }
}
