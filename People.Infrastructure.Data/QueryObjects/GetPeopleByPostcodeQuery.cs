using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPeopleByPostcodeQuery : IQuery<List<Person>>
    {
        private readonly string _postcode;

        public GetPeopleByPostcodeQuery(string postcode)
        {
            _postcode = postcode;
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
                                            JOIN PersonAddress AS PA
                                            ON P.PersonId = PA.PersonId
                                            JOIN Address AS A
                                            ON PN.AddressId = N.AddressId
                                            WHERE A.ZipOrPostcode LIKE @Postcode
                                            AND PA.ToDate IS NULL",
                new
                {
                    Postcode = _postcode,
                },
                transaction).ToList();

            return people.Select(person => db.Query(new FillPersonQuery(person), transaction)).ToList();
        }
    }
}
