using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;

namespace GrupoBIOS.Domain.Interface
{
    public interface IUsuarioDomain : IDomain<Usuario>
    {
        Task<Usuario> GetLogin(LoginRequest login);
        Task<bool> DesactivarUsuario(int IDUsuario);
    }
}
