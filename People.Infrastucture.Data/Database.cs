using System.Data;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data
{
    public class Database : IDatabase
    {
        private readonly IDbConnection _dbConnection;

        public Database(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IDbTransaction BeginTransaction()
        {
            return _dbConnection.BeginTransaction();
        }

        public T Query<T>(IQuery<T> query)
        {
            return query.Query(_dbConnection);
        }

        public T QueryWithTransaction<T>(IQuery<T> query, IDbTransaction transaction)
        {
            return query.QueryWithTransaction(_dbConnection, transaction);
        }

        public void Execute(ICommand command)
        {
            command.Execute(_dbConnection);
        }

        public void ExecuteWithTransaction(ICommand command, IDbTransaction transaction)
        {
            command.ExecuteWithTransaction(_dbConnection, transaction);
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }
    }
}
