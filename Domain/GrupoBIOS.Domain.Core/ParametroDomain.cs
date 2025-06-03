using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Interface;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Utils;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.Domain.Core
{
    public class ParametroDomain : IParametroDomain
    {
        private readonly IUnitOfWork _unityOfWork;
        public IConfiguration Configuration { get; }
        public ParametroDomain(IUnitOfWork unityOfWork, IConfiguration configuration)
        {
            _unityOfWork = unityOfWork;
            Configuration = configuration;
        }
        public async Task<bool> DeleteAsync(int ID)
        {
            return await _unityOfWork.Parametros.DeleteAsync(ID);
        }

        public async Task<IEnumerable<Parametro>> GetAllAsync()
        {
            return await _unityOfWork.Parametros.GetAllAsync();
        }

        public async Task<Parametro> GetAsync(int ID)
        {
            return await _unityOfWork.Parametros.GetAsync(ID);
        }

        public async Task<string> InsertAsync(Parametro model)
        {
            return await _unityOfWork.Parametros.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Parametro model)
        {
            return await _unityOfWork.Parametros.UpdateAsync(model);
        }
        public async Task<IEnumerable<Parametro>> GetParametroClase(int IDClase)
        {
            return await _unityOfWork.Parametros.GetParametroClase(IDClase);
        }
        public async Task<string> DesactivarParametro(int IDParametro)
        {
            return await _unityOfWork.Parametros.DesactivarParametro(IDParametro);
        }
    }
}
