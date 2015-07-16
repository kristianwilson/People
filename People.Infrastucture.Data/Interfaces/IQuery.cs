using System.Data;

namespace People.Infrastucture.Data.Interfaces
{
    public interface IQuery<out T>
    {
        T Query(IDbConnection db);
        T QueryWithTransaction(IDbConnection db, IDbTransaction transaction);
    }
}
