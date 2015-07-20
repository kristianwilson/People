using System.Data;
using System.Linq;
using Dapper;
using People.Core.Objects;
using People.Infrastucture.Data.Interfaces;

namespace People.Infrastucture.Data.QueryObjects
{
    public class FillPersonWithHistoricsQuery : IQuery<PersonWithHistory>
    {
        private readonly PersonWithHistory _person;

        public FillPersonWithHistoricsQuery(PersonWithHistory person)
        {
            _person = person;
        }

        public PersonWithHistory Query(IDbConnection db)
        {
            return QueryWithTransaction(db, null);
        }

        public PersonWithHistory QueryWithTransaction(IDbConnection db, IDbTransaction transaction)
        {
            _person.Names = db.Query<Name>(@" SELECT  N.NameId, 
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
                                                WHERE PN.PersonId = @PersonId",
                    new
                    {
                        _person.PersonId
                    },
                    transaction).ToList();

            _person.Emails = db.Query<EmailAddress>(@"SELECT  E.EmailAddressId,
                                                                E.Email,
                                                                EN.EmailAddressTypeId AS AddressType
                                                                EN.DoNotUse, 
                                                                EN.FromDate, 
                                                                EN.ToDate
                                                        FROM PersonEmailAddress AS PE
                                                        JOIN EmailAddress AS E
                                                        ON PE.EmailAddressId = E.EmailAddressId
                                                        WHERE EN.PersonId = @PersonId",
                new
                {
                    _person.PersonId
                },
                transaction).ToList();

            _person.Mobiles = db.Query<TelephoneNumber>(@"SELECT  T.TelephoneNumberId,
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
                                                            AND PT.TelephoneNumberTypeId = @TypeId",
                new
                {
                    _person.PersonId,
                    TypeId = (int)TelephoneNumberType.Mobile
                },
                transaction).ToList();


            _person.Landlines = db.Query<TelephoneNumber>(@"  SELECT  T.TelephoneNumberId,
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
                                                                AND PT.TelephoneNumberTypeId = @TelephoneNumberTypeId",
                new
                {
                    _person.PersonId,
                    TypeId = (int)TelephoneNumberType.Landline
                },
                transaction).ToList();


            _person.Addresses = db.Query<Address>(@"   SELECT  A.AddressId,
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
                                                        WHERE PA.PersonId = @PersonId",
                new
                {
                    _person.PersonId
                },
                transaction).ToList();

            return _person;
        }
    }
}
