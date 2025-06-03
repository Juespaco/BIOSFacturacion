using System.Data;
using System.Data.Common;

namespace GrupoBIOS.Transversal.Common
{
    public interface IConnectionFactory
    {
        IDbConnection GetConnection { get; }
    }

    /*
    public interface IConnectionFactory
    {
        // Para compatibilidad (opcional)
        IDbConnection GetConnection { get; }

        // Nueva versión async que devuelve DbConnection
        Task<DbConnection> GetDbConnectionAsync();
    }
    */
}
