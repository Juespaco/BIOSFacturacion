using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;

using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using GrupoBIOS.Transversal.Utils;
using GrupoBIOS.Domain.Entity.Request.Auth;
using System.Reflection;

namespace GrupoBIOS.Domain.Core
{
    public class CompaniaDomain : ICompaniaDomain
    {

        private readonly IUnitOfWork _unityOfWork;

        public CompaniaDomain(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _unityOfWork.Compania.DeleteAsync(ID);
        }

        public async Task<bool> DesactivarCompania(int IDCompania)
        {
            return await _unityOfWork.Compania.DesactivarCompania(IDCompania);
        }

        public async Task<IEnumerable<Compania>> GetAllAsync()
        {
            return await _unityOfWork.Compania.GetAllAsync();
        }

        public async Task<Compania> GetAsync(int ID)
        {
            return await _unityOfWork.Compania.GetAsync(ID);
        }

        public async Task<string> InsertAsync(Compania model)
        {
            return await _unityOfWork.Compania.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Compania model)
        {
            return await _unityOfWork.Compania.UpdateAsync(model);
        }

        public async Task<ConfiguracionCompania> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa)
        {
            return await _unityOfWork.Compania.ObtenerConfiguracionPorIDSiesaAsync(IDSiesa);
        }

    }
}
