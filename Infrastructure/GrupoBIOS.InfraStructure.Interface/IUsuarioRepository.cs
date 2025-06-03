using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;

namespace GrupoBIOS.InfraStructure.Interface
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario> GetLogin(LoginRequest login);
        Task<bool> DesactivarUsuario(int IDUsuario);
    }
}
