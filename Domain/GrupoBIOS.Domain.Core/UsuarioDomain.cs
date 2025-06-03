using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Interface;

using GrupoBIOS.InfraStructure.Interface;
using Microsoft.Extensions.Configuration;
using GrupoBIOS.Transversal.Utils;
using GrupoBIOS.Domain.Entity.Request.Auth;
using System.Reflection;

namespace GrupoBIOS.Domain.Core
{
    public class UsuarioDomain : IUsuarioDomain
    {
        private readonly IUnitOfWork _unityOfWork;
        //private readonly IUsuarioRepository _Repository;
        public IConfiguration Configuration { get; }
        private Cifrador cifrador;

        //IUsuarioRepository repository, 
        public UsuarioDomain(IUnitOfWork unityOfWork, IConfiguration configuration)
        {
            _unityOfWork = unityOfWork;
            //_Repository = repository;
            Configuration = configuration;
            cifrador = new Cifrador();
        }
               
        public async Task<bool> DeleteAsync(int ID)
        {
            return await _unityOfWork.Usuarios.DeleteAsync(ID);
            //return await _Repository.DeleteAsync(ID);
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await _unityOfWork.Usuarios.GetAllAsync();
            //return await _Repository.GetAllAsync();
        }

        public async Task<Usuario> GetAsync(int ID)
        {
            return await _unityOfWork.Usuarios.GetAsync(ID);
            //return await _Repository.GetAsync(ID);
        }

        public async Task<string> InsertAsync(Usuario model)
        {
            //Configuration
            var keyBase = Configuration.GetSection("KeyBase").Value;
            model.Contrasena = cifrador.Encriptar(model.Contrasena, keyBase!);
            return await _unityOfWork.Usuarios.InsertAsync(model);
            //return await _Repository.InsertAsync(model);
        }

        public async Task<string> UpdateAsync(Usuario model)
        {
            //Se valida si la contraseña ha tenido cambios para actualizar.
            if (model.Contrasena != string.Empty)
            {
                var keyBase = Configuration.GetSection("KeyBase").Value;
                model.Contrasena = cifrador.Encriptar(model.Contrasena, keyBase!);
            }
            return await _unityOfWork.Usuarios.UpdateAsync(model);
            //return await _Repository.UpdateAsync(model);
        }

        public async Task<Usuario> GetLogin(LoginRequest login)
        {
            var keyBase = Configuration.GetSection("KeyBase").Value;            
            login.Contrasena = cifrador.Encriptar(login.Contrasena, keyBase!);
            return await _unityOfWork.Usuarios.GetLogin(login);
        }

        public async Task<bool> DesactivarUsuario(int IDUsuario)
        {
            return await _unityOfWork.Usuarios.DesactivarUsuario(IDUsuario);
        }
    }
}
