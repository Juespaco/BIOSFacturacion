using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;

using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using GrupoBIOS.Transversal.Utils;
using GrupoBIOS.Domain.Entity.Request.Auth;
using System.Reflection;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;

namespace GrupoBIOS.Domain.Core
{
    public class NivelDomain : INivelDomain
    {
        private readonly IUnitOfWork _unitOfWork;

        public NivelDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CrearActualizarNivelesAsync(IEnumerable<Nivel> niveles)
        {
            return await _unitOfWork.Nivel.CrearActualizarNivelesAsync(niveles);
        }
    }

}
