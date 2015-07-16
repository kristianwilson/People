using System.Data;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data
{
    public static class DbConnectionExtension
    {
        public static T Query<T>(this IDbConnection connection, IQuery<T> query, IDbTransaction transaction)
        {
            return query.QueryWithTransaction(connection, transaction);
        }

        public static void Execute(this IDbConnection connection, ICommand command, IDbTransaction transaction)
        {
            command.ExecuteWithTransaction(connection, transaction);
        }
    }
}
