
using Dapper;
using GrupoBIOS.Domain.Entity;
using GrupoBIOS.Domain.Entity.Request.Auth;
using GrupoBIOS.Domain.Entity.TuProyecto.Domain.Entities;
using GrupoBIOS.InfraStructure.Interface;
using GrupoBIOS.Transversal.Common;
using System.Data;

namespace GrupoBIOS.InfraStructure.Repository
{
    public class NivelRepository : INivelRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public NivelRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task<string> CrearActualizarNivelesAsync(IEnumerable<Nivel> niveles)
        {
            using var connection = _connectionFactory.GetConnection;

            var table = new DataTable();
            table.Columns.Add("IDNivel", typeof(int));
            table.Columns.Add("NivelCentroOperativo", typeof(int));
            table.Columns.Add("NivelNombre", typeof(string));
            table.Columns.Add("NivelDiasGracia", typeof(int));
            table.Columns.Add("NivelDiasCobertura", typeof(int));
            table.Columns.Add("NivelPosicion", typeof(double));
            table.Columns.Add("NivelPrimerCobro", typeof(int));
            table.Columns.Add("NivelSegundoCobro", typeof(int));

            foreach (var item in niveles)
            {
                table.Rows.Add(
                    item.IDNivel,
                    item.NivelCentroOperativo,
                    item.NivelNombre,
                    item.NivelDiasGracia,
                    item.NivelDiasCobertura,
                    item.NivelPosicion,
                    item.NivelPrimerCobro,
                    item.NivelSegundoCobro
                );
            }

            var parameters = new DynamicParameters();
            parameters.Add("@Niveles", table.AsTableValuedParameter("NivelType"));

            await connection.ExecuteAsync("sp_Nivel_CrearActualizar", parameters, commandType: CommandType.StoredProcedure);
            return "OK";
        }
    }

}
