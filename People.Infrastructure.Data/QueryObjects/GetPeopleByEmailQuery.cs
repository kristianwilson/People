using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPeopleByEmailQuery : IQuery<List<Person>>
    {
        private readonly string _email;

        public GetPeopleByEmailQuery(string email)
        {
            _email = email;
        }

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
                                            FROM Person AS P
                                            JOIN PersonEmailAddress AS PE
                                            ON P.PersonId = PE.PersonId
                                            JOIN EmailAddress AS E
                                            ON PE.EmailAddressId = E.EmailAddressId
                                            WHERE E.Email = @Mobile
                                            AND PE.ToDate IS NULL",
                new
                {
                    Email = _email,
                },
                transaction).ToList();

            return people.Select(person => db.Query(new FillPersonQuery(person), transaction)).ToList();
        }
    }
}
