using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.DTOs.Request.Auth;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IParametroApplication : IApplication<ParametroDTO>
    {
        Task<Response<IEnumerable<ParametroDTO>>> GetParametroClase(int IDClase);
        Task<Response<string>> DesactivarParametro(int IDParametro);
    }
}
