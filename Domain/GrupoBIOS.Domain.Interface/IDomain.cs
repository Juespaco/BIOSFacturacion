namespace GrupoBIOS.Domain.Interface
{
    public interface IDomain<T>
    {
        Task<string> InsertAsync(T model);
        Task<string> UpdateAsync(T model);
        Task<bool> DeleteAsync(int ID);
        Task<T> GetAsync(int ID);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
