using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPeopleQuery : IQuery<List<Person>>
    {
        public List<Person> Query(IDbConnection db)
        {
            return QueryWithTransaction(db, null);
        }

        public List<Person> QueryWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            var people = db.Query<Person>(@"SELECT  PersonId,
                                                    PersonUid,
                                                    GenderTypeId AS Gender,
                                                    DateOfBirth,
                                                    DeathDate,
                                                    Blacklisted,
                                            FROM Person",
                transaction).ToList();

            return people.Select(person => db.Query(new FillPersonQuery(person), transaction)).ToList();
        }
    }
}
