using System;
using System.Data;
using Dapper;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class BlacklistPersonCommand : ICommand
    {
        private readonly Guid _personUid;

        public BlacklistPersonCommand(Guid personUid)
        {
            _personUid = personUid;
        }

        public void Execute(IDbConnection db)
        {
            ExecuteWithTransaction(db, null);
        }

        public void ExecuteWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            db.Execute(@"   UPDATE Person 
                            SET Blacklisted = 1
                            WHERE PersonUid = @PersonUid",
                new
                {
                    PersonUid = _personUid,
                }
                , transaction);
        }
    }
}
