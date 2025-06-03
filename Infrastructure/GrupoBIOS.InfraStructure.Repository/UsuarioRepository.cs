
using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public UsuarioRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "uspDelUsuario";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDUsuario", ID);
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result == null || result == "success";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<bool> DesactivarUsuario(int IDUsuario)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "uspDesactivarUsuario";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDUsuario", IDUsuario);
                    parameters.Add("@Estado", false);
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result == "OK";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspGetUsuarioAll";
                    var result = await connection.QueryAsync<Usuario>(query, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Usuario> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetUsuarioporId";
                var parameters = new DynamicParameters();

                parameters.Add("IDUsuario", ID);

                try
                {
                    using (var multi = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure))
                    {
                        var usuario = await multi.ReadSingleOrDefaultAsync<Usuario>();
                        if (usuario != null)
                        {
                            usuario.InfoPersonal = await multi.ReadSingleOrDefaultAsync<InfoPersonal>();
                        }
                        return usuario!;
                    }

                    //var result = await connection.QuerySingleAsync<Usuario>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    //return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<Usuario> GetLogin(LoginRequest login)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetUsuarioporLogin";
                var parameters = new DynamicParameters();
                parameters.Add("NombredeUsuario", login.NombredeUsuario);
                parameters.Add("Contrasena", login.Contrasena);

                using (var multi = await connection.QueryMultipleAsync(query, parameters, commandType: CommandType.StoredProcedure))
                {
                    var usuario = await multi.ReadSingleOrDefaultAsync<Usuario>();
                    if (usuario != null)
                    {
                        usuario.InfoPersonal = await multi.ReadSingleOrDefaultAsync<InfoPersonal>();
                    }
                    return usuario!;
                }
            }
        }

        public async Task<string> InsertAsync(Usuario model)
        {
            try
            {
                string jsonInfoPersonal = System.Text.Json.JsonSerializer.Serialize(model.InfoPersonal);

                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspCrearUsuario";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDRol", model.IDRol);
                    parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@IDCentroOperativo", model.IDCentroOperativo);
                    parameters.Add("@FechaExpiracionRol", model.FechaExpiracionRol);
                    parameters.Add("@NombredeUsuario", model.NombredeUsuario);
                    parameters.Add("@Contrasena", model.Contrasena);
                    parameters.Add("@Estado", model.Estado);
                    parameters.Add("@CreadoPor", model.CreadoPor);
                    parameters.Add("@JsonInfoPersona", jsonInfoPersonal);
                    
                    //Persistir la info en la bd
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result!;                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateAsync(Usuario model)
        {
            try
            {
                string jsonInfoPersonal = System.Text.Json.JsonSerializer.Serialize(model.InfoPersonal);

                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspActualizarUsuario";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDUsuario", model.IDUsuario);
                    parameters.Add("@IDRol", model.IDRol);
                    parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@IDCentroOperativo", model.IDCentroOperativo);
                    parameters.Add("@FechaExpiracionRol", model.FechaExpiracionRol);
                    parameters.Add("@NombredeUsuario", model.NombredeUsuario);
                    parameters.Add("@Contrasena", string.IsNullOrEmpty(model.Contrasena) ? null : model.Contrasena);
                    parameters.Add("@Estado", model.Estado);
                    parameters.Add("@CreadoPor", model.CreadoPor);
                    parameters.Add("@JsonInfoPersona", jsonInfoPersonal);

                    //Persistir la info en la bd
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result!;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
