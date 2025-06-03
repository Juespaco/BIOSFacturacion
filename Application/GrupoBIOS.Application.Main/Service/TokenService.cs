using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using GrupoBIOS.Transversal.Common;
using GrupoBIOS.Application.DTOs;
using GrupoBIOS.Application.Interface.Service;
using Microsoft.Extensions.Options;

namespace GrupoBIOS.Application.Main.Service
{
    public class TokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public TokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public string GenerateToken(UsuarioDTO usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret!);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.IDUsuario.ToString()),
                new Claim(ClaimTypes.Name, usuario.NombredeUsuario),
                new Claim(ClaimTypes.Role, usuario.IDRol.ToString()),
                new Claim("NombreRol", usuario!.NombreRol!),
                new Claim("CompaniaId", usuario.IDCompania.ToString()),
                new Claim("Nombre", usuario!.InfoPersonal!.Nombres + " " + usuario!.InfoPersonal!.Apellidos),
                // Agrega más claims según necesites
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(2), // Token expira en 2 horas
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
