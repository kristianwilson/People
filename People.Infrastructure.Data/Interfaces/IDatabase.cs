using System;
using System.Data;

namespace People.Infrastucture.Data.Interfaces
{
    public interface IDatabase : IDisposable
    {
        IDbTransaction BeginTransaction();
        T Query<T>(IQuery<T> query);
        T QueryWithTransaction<T>(IQuery<T> query, IDbTransaction transaction);
        void Execute(ICommand command);
        void ExecuteWithTransaction(ICommand command, IDbTransaction transaction);
    }
}
