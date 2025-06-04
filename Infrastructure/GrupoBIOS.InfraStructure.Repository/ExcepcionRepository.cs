
using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class ExcepcionRepository : IExcepcionRepository
    {

        private readonly IConnectionFactory _connectionFactory;
        public ExcepcionRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public async Task<string> CrearActualizarExcepcionesAsync(IEnumerable<Excepcion> excepciones)
        {
            using var connection = _connectionFactory.GetConnection;

            var dataTable = new DataTable();
            dataTable.Columns.Add("IdExcepcion", typeof(int));
            dataTable.Columns.Add("IdCompania", typeof(int));
            dataTable.Columns.Add("Planta", typeof(string));
            dataTable.Columns.Add("Nit", typeof(string));
            dataTable.Columns.Add("NombreCliente", typeof(string));
            dataTable.Columns.Add("Estado", typeof(bool));
            dataTable.Columns.Add("CreadoPor", typeof(string));

            foreach (var ex in excepciones)
            {
                dataTable.Rows.Add(
                    ex.IdExcepcion ?? 0, // 0 si es nuevo
                    ex.IdCompania,
                    ex.Planta,
                    ex.Nit,
                    ex.NombreCliente,
                    ex.Estado,
                    ex.CreadoPor
                );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Excepciones", dataTable.AsTableValuedParameter("ExcepcionType"));

            await connection.ExecuteAsync("sp_Excepciones_CrearActualizar", parameters, commandType: CommandType.StoredProcedure);

            return "OK";
        }


    }
}
