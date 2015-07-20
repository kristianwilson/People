using System;
using System.Data;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class DeletePersonCommand : ICommand
    {
        private readonly Guid _personUid;

        public DeletePersonCommand(Guid personUid)
        {
            _personUid = personUid;
        }

        public void Execute(IDbConnection db)
        {
            ExecuteWithTransaction(db, null);
        }

        public void ExecuteWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
