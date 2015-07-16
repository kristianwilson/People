using System.Data.SqlClient;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data
{
    public class DbFactory : IDbFactory
    {
        private readonly string _connectionString;

        public DbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDatabase GetDatabase()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();

            return new Database(connection);
        }
    }
}
