using System.Data;

namespace People.Infrastucture.Data.Interfaces
{
    public interface ICommand
    {
        void Execute(IDbConnection db);
        void ExecuteWithTransaction(IDbConnection db, IDbTransaction transaction);
    }
}
