using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class CentroOperativoRepository : ICentroOperativoRepository
    {
        private readonly IConnectionFactory _connectionFactory;
        public CentroOperativoRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<bool> DeleteAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "uspDelCentroOperativo";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDCentroOperativo", ID);
                    var result = await connection.QuerySingleOrDefaultAsync<string>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result == null || result == "success";
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<bool> DesactivarCentroOperativo(int IDCentroOperativo)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                try
                {
                    var query = "sp_CentroOperativo_CambiarEstado";
                    var parameters = new DynamicParameters();
                    parameters.Add("@IDCentroOperativo", IDCentroOperativo);
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

        public async Task<IEnumerable<CentroOperativo>> GetAllAsync()
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_CentroOperativo_ObtenerTodos";
                    var result = await connection.QueryAsync<CentroOperativo>(query, commandType: CommandType.StoredProcedure);

                    return result;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CentroOperativo> GetAsync(int ID)
        {
            using (var connection = _connectionFactory.GetConnection)
            {
                var query = "sp_CentroOperativo_ObtenerPorId";
                var parameters = new DynamicParameters();

                parameters.Add("IDCentroOperativo", ID);

                try
                {
                    var result = await connection.QuerySingleOrDefaultAsync<CentroOperativo>(query, param: parameters, commandType: CommandType.StoredProcedure);
                    return result!;
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }

        public async Task<string> InsertAsync(CentroOperativo model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_CentroOperativo_Insertar";
                    var parameters = new DynamicParameters();
                    
                    parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@IDSiesaCO", model.IDSiesaCO);
                    parameters.Add("@NombreCO", model.NombreCO);
                    parameters.Add("@ReferenciadeCobro", model.ReferenciadeCobro);
                    parameters.Add("@PrefijodeFacturacion", model.PrefijodeFacturacion);
                    parameters.Add("@MotivodeFacturacion", model.MotivodeFacturacion);
                    parameters.Add("@BodegaEspeciales", model.BodegaEspeciales);
                    parameters.Add("@CorreoEnvioReporte", model.CorreoEnvioReporte);
                    parameters.Add("@FechaInicialCorte", model.FechaInicialCorte);
                    parameters.Add("@CobroPNC", model.CobroPNC);
                    //parameters.Add("@Estado", model.Estado);
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

        public async Task<string> UpdateAsync(CentroOperativo model)
        {
            try
            {
                using (var connection = _connectionFactory.GetConnection)
                {
                    var query = "sp_CentroOperativo_Actualizar";
                    var parameters = new DynamicParameters();

                    parameters.Add("@IDCentroOperativo", model.IDCentroOperativo);
                    parameters.Add("@IDCompania", model.IDCompania);
                    parameters.Add("@IDSiesaCO", model.IDSiesaCO);
                    parameters.Add("@NombreCO", model.NombreCO);
                    parameters.Add("@ReferenciadeCobro", model.ReferenciadeCobro);
                    parameters.Add("@PrefijodeFacturacion", model.PrefijodeFacturacion);
                    parameters.Add("@MotivodeFacturacion", model.MotivodeFacturacion);
                    parameters.Add("@BodegaEspeciales", model.BodegaEspeciales);
                    parameters.Add("@CorreoEnvioReporte", model.CorreoEnvioReporte);
                    parameters.Add("@FechaInicialCorte", model.FechaInicialCorte);
                    parameters.Add("@CobroPNC", model.CobroPNC);
                    //parameters.Add("@Estado", model.Estado);
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

        public async Task<string> CrearActualizarCentroOperativoAsync(IEnumerable<CentroOperativo> centros)
        {
            using var connection = _connectionFactory.GetConnection;

            var table = new DataTable();
            table.Columns.Add("IDCentroOperativo", typeof(int));
            table.Columns.Add("IDCompania", typeof(int));
            table.Columns.Add("IDSiesaCO", typeof(int));
            table.Columns.Add("NombreCO", typeof(string));
            table.Columns.Add("ReferenciadeCobro", typeof(string));
            table.Columns.Add("PrefijodeFacturacion", typeof(string));
            table.Columns.Add("MotivodeFacturacion", typeof(string));
            table.Columns.Add("BodegaEspeciales", typeof(string));
            table.Columns.Add("CorreoEnvioReporte", typeof(string));
            table.Columns.Add("FechaInicialCorte", typeof(DateTime));
            table.Columns.Add("CobroPNC", typeof(int));
            table.Columns.Add("Estado", typeof(bool));
            table.Columns.Add("FechadeCreacion", typeof(DateTime));
            table.Columns.Add("CreadoPor", typeof(string));

            foreach (var c in centros)
            {
                table.Rows.Add(
                    c.IDCentroOperativo,
                    c.IDCompania,
                    c.IDSiesaCO,
                    c.NombreCO,
                    c.ReferenciadeCobro,
                    c.PrefijodeFacturacion,
                    c.MotivodeFacturacion,
                    c.BodegaEspeciales,
                    c.CorreoEnvioReporte,
                    c.FechaInicialCorte,
                    c.CobroPNC,
                    c.Estado,
                    c.FechadeCreacion,
                    c.CreadoPor
                );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@CentroOperativos", table.AsTableValuedParameter("CentroOperativoType"));

            await connection.ExecuteAsync("sp_CentroOperativo_CrearActualizar", parameters, commandType: CommandType.StoredProcedure);

            return "OK";
        }
    }
}
