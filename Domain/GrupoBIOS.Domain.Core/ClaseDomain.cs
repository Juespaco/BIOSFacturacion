using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;

namespace GrupoBIOS.Domain.Core
{
    public class ClaseDomain : IClaseDomain
    {
        private readonly IUnitOfWork _unityOfWork;
        public IConfiguration Configuration { get; }
        public ClaseDomain(IUnitOfWork unityOfWork, IConfiguration configuration)
        {
            _unityOfWork = unityOfWork;
            Configuration = configuration;
        }
        public async Task<bool> DeleteAsync(int ID)
        {
            return await _unityOfWork.Clases.DeleteAsync(ID);
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            return await _unityOfWork.Clases.GetAllAsync();
        }

        public async Task<Clase> GetAsync(int ID)
        {
            return await _unityOfWork.Clases.GetAsync(ID);
        }

        public async Task<string> InsertAsync(Clase model)
        {
            return await _unityOfWork.Clases.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Clase model)
        {
            return await _unityOfWork.Clases.UpdateAsync(model);
        }
        public async Task<string> DesactivarClase(int IDClase)
        {
            return await _unityOfWork.Clases.DesactivarClase(IDClase);
        }
    }
}
