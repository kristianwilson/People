using System;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPersonWithHistoricsByIdQuery : IQuery<PersonWithHistory>
    {
        private readonly Guid _personUid;

        public GetPersonWithHistoricsByIdQuery(Guid personUid)
        {
            _personUid = personUid;
        }

        public PersonWithHistory Query(IDbConnection db)
        {
            return QueryWithTransaction(db, null);
        }

        public PersonWithHistory QueryWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            var person = db.Query<PersonWithHistory>(@"SELECT  PersonId,
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
                person = db.Query(new FillPersonWithHistoricsQuery(person), transaction);
            }

            return person;
        }
    }
}
