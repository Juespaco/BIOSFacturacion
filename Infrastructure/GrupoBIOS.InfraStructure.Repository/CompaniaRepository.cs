
using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class CompaniaRepository : ICompaniaRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        public CompaniaRepository(IConnectionFactory connectionFactory)
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

        public async Task<bool> DesactivarCompania(int IDCompania)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "sp_Compania_CambiarEstado";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDCompania", IDCompania);
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

        public async Task<IEnumerable<Compania>> GetAllAsync()
        {
            //sp_Compania_ObtenerTodos
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_Compania_ObtenerTodos";
                    var result = await connection.QueryAsync<Compania>(query, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Compania> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_Compania_ObtenerPorId";
                var parameters = new DynamicParameters();

                parameters.Add("IDSiesa", ID);

                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Compania>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result!;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<string> InsertAsync(Compania model)
        {
            try
            {                
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_Compania_Insertar";
                    var parameters = new DynamicParameters();
                    
                    //parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@NombreCompania", model.NombreCompania);
                    parameters.Add("@IDSiesa", model.IDSiesa);
                    parameters.Add("@NombreBD", model.NombreBD);
                    parameters.Add("@NombreConexionBD", model.NombreConexionBD);
                    parameters.Add("@UrlWebServiceSiesa", model.UrlWebServiceSiesa);
                    parameters.Add("@UsuarioWebService", model.UsuarioWebService);
                    parameters.Add("@ClaveWebService", model.ClaveWebService);
                    parameters.Add("@CreadoPor", model.CreadoPor);

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

        public async Task<string> UpdateAsync(Compania model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_Compania_Actualizar";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@NombreCompania", model.NombreCompania);
                    parameters.Add("@IDSiesa", model.IDSiesa);
                    parameters.Add("@NombreBD", model.NombreBD);
                    parameters.Add("@NombreConexionBD", model.NombreConexionBD);
                    parameters.Add("@UrlWebServiceSiesa", model.UrlWebServiceSiesa);
                    parameters.Add("@UsuarioWebService", model.UsuarioWebService);
                    parameters.Add("@ClaveWebService", model.ClaveWebService);
                    parameters.Add("@Estado", model.Estado);

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

        public async Task<ConfiguracionCompania> ObtenerConfiguracionPorIDSiesaAsync(int IDSiesa)
        {
            using var connection = _connectionFactory.GetConnection;
            var parameters = new DynamicParameters();
            parameters.Add("IDSiesa", IDSiesa);

            var result = new ConfiguracionCompania();

            try
            {
                using var multi = await connection.QueryMultipleAsync("sp_Compania_ObtenerConfiguracionPorId", parameters, commandType: CommandType.StoredProcedure);

                result.Compania = await multi.ReadSingleOrDefaultAsync<Compania>() ?? new Compania();
                result.Notificacion = await multi.ReadSingleOrDefaultAsync<Notificacion>()?? new Notificacion();
                result.Niveles = (await multi.ReadAsync<Nivel>()).ToList();
                result.CentrosOperativos = (await multi.ReadAsync<CentroOperativo>()).ToList();
                result.Pncs = (await multi.ReadAsync<Pnc>()).ToList();
                result.Excepciones = (await multi.ReadAsync<Excepcion>()).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
