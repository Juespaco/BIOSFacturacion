using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class ClaseRepository : IClaseRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public ClaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "uspDelClase";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDCLase", ID);
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result == null || result == "success";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<IEnumerable<Clase>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspGetClaseAll";
                    var result = await connection.QueryAsync<Clase>(query, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Clase> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "uspGetClaseporId";
                var parameters = new DynamicParameters();

                parameters.Add("IDClase", ID);

                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<Clase>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result!;
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public async Task<string> InsertAsync(Clase model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspCrearClase";
                    var parameters = new DynamicParameters();

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

        public async Task<string> UpdateAsync(Clase model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspActualizarClase";
                    var parameters = new DynamicParameters();

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
        public async Task<string> DesactivarClase(int IDClase)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "uspDelClase";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDClase", IDClase);
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
