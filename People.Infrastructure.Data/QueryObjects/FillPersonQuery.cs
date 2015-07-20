using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class FillPersonQuery : IQuery<Person>
    {
        private readonly Person _person;

        public FillPersonQuery(Person person)
        {
            _person = person;
        }

        public Person Query(IDbConnection db)
        {
            return QueryWithTransaction(db, null);
        }

        public Person QueryWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            _person.Name = db.Query<Name>(@" SELECT  N.NameId, 
                                                        N.TitleId As Title, 
                                                        N.GivenName, 
                                                        N.AdditionalName, 
                                                        N.FamilyName, 
                                                        N.KnownAs, 
                                                        PN.DoNotUse, 
                                                        PN.FromDate, 
                                                        PN.ToDate
                                                FROM PersonName AS PN
                                                JOIN Name AS N
                                                ON PN.Name_NameId = N.NameId
                                                WHERE PN.PersonId = @PersonId
                                                AND PN.ToDate IS NULL",
                    new
                    {
                        _person.PersonId
                    },
                    transaction).FirstOrDefault();

            _person.Email = db.Query<EmailAddress>(@"SELECT  E.EmailAddressId,
                                                                E.Email,
                                                                EN.EmailAddressTypeId AS AddressType
                                                                EN.DoNotUse, 
                                                                EN.FromDate, 
                                                                EN.ToDate
                                                        FROM PersonEmailAddress AS PE
                                                        JOIN EmailAddress AS E
                                                        ON PE.EmailAddressId = E.EmailAddressId
                                                        WHERE EN.PersonId = @PersonId
                                                        AND EN.ToDate IS NULL",
                new
                {
                    _person.PersonId
                },
                transaction).FirstOrDefault();

            _person.Mobile = db.Query<TelephoneNumber>(@"SELECT  T.TelephoneNumberId,
                                                                    PT.TelephoneTypeId AS TelephoneType,
                                                                    T.Number,
                                                                    PT.TelephoneNumberTypeId AS TelephoneNumberType,
                                                                    PT.DoNotUse,
                                                                    PT.FromDate,
                                                                    PT.ToDate
                                                            FROM PersonTelephoneNumber AS PT
                                                            JOIN TelephoneNumber AS T
                                                            ON PT.TelephoneNumberId = T.TelephoneNumberId
                                                            WHERE PT.PersonId = @PersonId
                                                            AND PT.TelephoneNumberTypeId = @TypeId
                                                            AND PT.ToDate IS NULL",
                new
                {
                    _person.PersonId,
                    TypeId = (int)TelephoneNumberType.Mobile
                },
                transaction).FirstOrDefault();


            _person.Landline = db.Query<TelephoneNumber>(@"  SELECT  T.TelephoneNumberId,
                                                                        PT.TelephoneTypeId AS TelephoneType,
                                                                        T.Number,
                                                                        PT.TelephoneNumberTypeId AS TelephoneNumberType,
                                                                        PT.DoNotUse,
                                                                        PT.FromDate,
                                                                        PT.ToDate
                                                                FROM PersonTelephoneNumber AS PT
                                                                JOIN TelephoneNumber AS T
                                                                ON PT.TelephoneNumberId = T.TelephoneNumberId
                                                                WHERE PT.PersonId = @PersonId
                                                                AND PT.TelephoneNumberTypeId = @TelephoneNumberTypeId
                                                                AND PT.ToDate IS NULL",
                new
                {
                    _person.PersonId,
                    TypeId = (int)TelephoneNumberType.Landline
                },
                transaction).FirstOrDefault();


            _person.Address = db.Query<Address>(@"   SELECT  A.AddressId,
                                                                A.Line1 AS AddressLine1,
                                                                A.Line2 AS AddressLine2,
                                                                A.Line3 AS AddressLine3,
                                                                A.Line4 AS AddressLine4,
                                                                A.ZipOrPostcode AS Postcode,
                                                                A.StateProvinceCounty AS County,
                                                                A.CountryCode,
                                                                A.Udprn,
                                                                PA.AddressTypeId AS AddressType,
                                                                PA.DoNotUse,
                                                                PA.FromDate,
                                                                PA.ToDate
                                                        FROM PersonAddress AS PA
                                                        JOIN Address AS A
                                                        ON PA.AddressId = A.AddressId
                                                        WHERE PA.PersonId = @PersonId
                                                        AND PA.ToDate IS NULL",
                new
                {
                    _person.PersonId
                },
                transaction).FirstOrDefault();

            return _person;
        }
    }
}
