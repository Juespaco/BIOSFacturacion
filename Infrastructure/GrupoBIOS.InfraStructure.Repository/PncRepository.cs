
using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class PncRepository : IPncRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public PncRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> CrearActualizarPncsAsync(IEnumerable<Pnc> pncs)
        {
            using var connection = _connectionFactory.GetConnection;

            var table = new DataTable();
            table.Columns.Add("IDPnc", typeof(int));
            table.Columns.Add("CoPnc", typeof(int));
            table.Columns.Add("NombrePnc", typeof(string));
            table.Columns.Add("CodigoPnc", typeof(string));
            table.Columns.Add("TarifaPnc", typeof(int));
            table.Columns.Add("FleteidaPnc", typeof(double));
            table.Columns.Add("FleteregPnc", typeof(double));

            foreach (var item in pncs)
            {
                table.Rows.Add(item.IDPnc, item.CoPnc, item.NombrePnc, item.CodigoPnc, item.TarifaPnc, item.FleteidaPnc, item.FleteregPnc);
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Pncs", table.AsTableValuedParameter("PncType"));

            await connection.ExecuteAsync("sp_Pnc_CrearActualizar", parameters, commandType: CommandType.StoredProcedure);
            return "OK";
        }
    }

}
