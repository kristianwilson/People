using System.Data;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class CreatePersonCommand : ICommand
    {
        private readonly Person _person;

        public CreatePersonCommand(Person person)
        {
            _person = person;
        }

        public void Execute(IDbConnection db)
        {
            ExecuteWithTransaction(db, null);
        }

        public void ExecuteWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            
        }
    }
}
