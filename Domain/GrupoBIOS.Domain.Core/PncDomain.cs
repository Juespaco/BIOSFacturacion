using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;

using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using GrupoBIOS.Transversal.Utils;
using GrupoBIOS.Domain.Entity.Request.Auth;
using System.Reflection;

namespace GrupoBIOS.Domain.Core
{
    public class PncDomain : IPncDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public PncDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CrearActualizarPncsAsync(IEnumerable<Pnc> pncs)
        {
            return await _unitOfWork.Pnc.CrearActualizarPncsAsync(pncs);
        }
    }

}
