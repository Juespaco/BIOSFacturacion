using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Transversal.Common;
using System.Security.Claims;
using System.Text;

namespace GrupoBIOS.Application.Interface.Service
{
    public interface ITokenService
    {
        string GenerateToken(UsuarioDTO usuario);
    }    
}
