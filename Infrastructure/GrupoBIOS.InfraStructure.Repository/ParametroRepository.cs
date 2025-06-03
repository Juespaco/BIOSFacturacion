using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class ParametroRepository : IParametroRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ParametroRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "uspDelParametro";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDParametro", ID);
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result == null || result == "success";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Parametro>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspGetParametroAll";
                    var result = await connection.QueryAsync<Parametro>(query, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Parametro> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetParametroporId";
                var parameters = new DynamicParameters();

                parameters.Add("IDParametro", ID);

                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Parametro>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result!;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<string> InsertAsync(Parametro model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspCrearParametro";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDParametro", model.IDParametro);
                    parameters.Add("@IDClase", model.IDClase);
                    parameters.Add("@Nombre", model.Nombre);
                    parameters.Add("@Descripcion", model.Descripcion);
                    parameters.Add("@Estado", model.Estado);
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

        public async Task<string> UpdateAsync(Parametro model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspActualizarParametro";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDParametro", model.IDParametro);
                    parameters.Add("@IDClase", model.IDClase);
                    parameters.Add("@Nombre", model.Nombre);
                    parameters.Add("@Descripcion", model.Descripcion);
                    parameters.Add("@Estado", model.Estado);
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
        public async Task<IEnumerable<Parametro>> GetParametroClase(int IDClase)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetParametroporClase";
                var parameters = new DynamicParameters();

                parameters.Add("IDClase", IDClase);

                try
                {
                    var result = await connection.QueryAsync<Parametro>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
        public async Task<string> DesactivarParametro(int IDParametro)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspDelParametro";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDParametro", IDParametro);
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
    }
}
