using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.InfraStructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Core
{
    public class CentroOperativoDomain : ICentroOperativoDomain
    {
        private readonly IUnitOfWork _unityOfWork;

        public CentroOperativoDomain(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            return await _unityOfWork.CentroOperativo.DeleteAsync(ID);
        }

        public async Task<bool> DesactivarCentroOperativo(int IDCompania)
        {
            return await _unityOfWork.CentroOperativo.DesactivarCentroOperativo(IDCompania);
        }

        public async Task<IEnumerable<CentroOperativo>> GetAllAsync()
        {
            return await _unityOfWork.CentroOperativo.GetAllAsync();
        }

        public async Task<CentroOperativo> GetAsync(int ID)
        {
            return await _unityOfWork.CentroOperativo.GetAsync(ID);
        }

        public async Task<string> InsertAsync(CentroOperativo model)
        {
            return await _unityOfWork.CentroOperativo.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(CentroOperativo model)
        {
            return await _unityOfWork.CentroOperativo.UpdateAsync(model);
        }
    }
}
