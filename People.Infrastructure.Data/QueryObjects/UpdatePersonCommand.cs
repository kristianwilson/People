using System;
using System.Data;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class UpdatePersonCommand : ICommand
    {
        private readonly Guid _personUid;
        private readonly Person _person;

        public UpdatePersonCommand(Guid personUid, Person person)
        {
            _personUid = personUid;
            _person = person;
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
