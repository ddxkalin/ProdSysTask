namespace Persistence
{
    using System.Data;
    using Microsoft.Data.SqlClient;
    using Microsoft.Extensions.Configuration;

    public class DataContext
    {
        private readonly IConfiguration _config;
        private readonly string _connectionString;

        public DataContext(IConfiguration config)
        {
            _config = config;
            _connectionString = _config.GetConnectionString("SqlConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}