using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;
using Dapper;

namespace People.Infrastucture.Data.QueryObjects
{
    public class GetPeopleByMobileQuery : IQuery<List<Person>>
    {
        private readonly string _mobile;

        public GetPeopleByMobileQuery(string mobile)
        {
            _mobile = mobile;
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
                                            JOIN PersonTelephoneNumber AS PT
                                            ON P.PersonId = PT.PersonId
                                            JOIN TelephoneNumber AS T
                                            ON PT.TelephoneNumberId = T.TelephoneNumberId
                                            WHERE T.Number = @Mobile
                                            AND PT.TelephoneNumberTypeId = @TypeId
                                            AND PT.ToDate IS NULL",
                new
                {
                    Mobile = _mobile,
                    TypeId = (int)TelephoneNumberType.Mobile,
                },
                transaction).ToList();

            return people.Select(person => db.Query(new FillPersonQuery(person), transaction)).ToList();
        }
    }
}
