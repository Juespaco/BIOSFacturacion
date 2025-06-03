using GrupoBIOS.Transversal.Common;
using Microsoft.Extensions.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Data.Common;


namespace GrupoBIOS.InfraStructure.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        /// <summary>
        /// Nos va a permitir acceder a las propiedades de los diferentes proyectos
        /// </summary>
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Método que nos permite acceder a la base de datos en GlobusConnection
        /// </summary>
        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();

                var connectionString = _configuration.GetConnectionString("BIOSConnection");
                if (string.IsNullOrEmpty(connectionString))
                {
                    throw new InvalidOperationException("Cadena de conexión 'BIOSConnection' no encontrada.");
                }

                sqlConnection.ConnectionString = connectionString;
                sqlConnection.Open();
                return sqlConnection;
            }
        }

    }

    /*
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Implementación tradicional (opcional)
        public IDbConnection GetConnection => GetDbConnectionAsync().GetAwaiter().GetResult();

        // Implementación moderna async
        public async Task<DbConnection> GetDbConnectionAsync()
        {
            var connectionString = _configuration.GetConnectionString("BIOSConnection");
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Cadena de conexión 'BIOSConnection' no encontrada.");
            }

            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }

    */
}
