using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPeopleBySurnameQuery : IQuery<List<Person>>
    {
        private readonly string _surname;

        public GetPeopleBySurnameQuery(string surname)
        {
            _surname = surname;
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
                                            JOIN PersonName AS PN
                                            ON P.PersonId = PN.PersonId
                                            JOIN Name AS N
                                            ON PN.NameId = N.NameId
                                            WHERE N.FamilyName = @FamilyName
                                            AND PN.ToDate IS NULL",
                new
                {
                    FamilyName = _surname,
                },
                transaction).ToList();

            return people.Select(person => db.Query(new FillPersonQuery(person), transaction)).ToList();
        }
    }
}
