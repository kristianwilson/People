using System;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPersonByIdQuery : IQuery<Person>
    {
        private readonly Guid _personUid;

        public GetPersonByIdQuery(Guid personUid)
        {
            _personUid = personUid;
        }

        public Person Query(IDbConnection db)
        {
            return QueryWithTransaction(db, null);
        }

        public Person QueryWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            var person = db.Query<Person>(@"SELECT  PersonId,
                                                    PersonUid,
                                                    GenderTypeId AS Gender,
                                                    DateOfBirth,
                                                    DeathDate,
                                                    Blacklisted,
                                            FROM Person
                                            WHERE PersonUid = @PersonUid",
                new
                {
                    PersonUid = _personUid
                },
                transaction).FirstOrDefault();

            if (person != null)
            {
                person = db.Query(new FillPersonQuery(person), transaction);
            }

            return person;
        }
    }
}
