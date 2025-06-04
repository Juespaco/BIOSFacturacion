using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;

using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using GrupoBIOS.Transversal.Utils;
using GrupoBIOS.Domain.Entity.Request.Auth;
using System.Reflection;

namespace GrupoBIOS.Domain.Core
{
    public class ExcepcionDomain : IExcepcionDomain
    {

        private readonly IUnitOfWork _unityOfWork;

        public ExcepcionDomain(IUnitOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }

        public async Task<string> CrearActualizarExcepcionesAsync(IEnumerable<Excepcion> model)
        {
            return await _unityOfWork.Excepcion.CrearActualizarExcepcionesAsync(model);
        }

    }
}
