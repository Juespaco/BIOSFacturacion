using GrupoBIOS.Transversal.Common;

namespace GrupoBIOS.Application.Interface
{
    public interface IApplication<T>
    {
        Task<Response<string>> InsertAsync(T modelDto);
        Task<Response<string>> UpdateAsync(T modelDto);
        Task<Response<bool>> DeleteAsync(int ID);
        Task<Response<T>> GetAsync(int ID);
        Task<Response<IEnumerable<T>>> GetAllAsync();
    }
}
