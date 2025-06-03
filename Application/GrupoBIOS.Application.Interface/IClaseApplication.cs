using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IClaseApplication : IApplication<ClaseDTO>
    {
        Task<Response<string>> DesactivarClase(int IDClase);
    }
}
