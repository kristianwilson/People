using System;
using System.Collections.Generic;
using System.Linq;

namespace People.Core.Objects
{
    public class Person
    {
        public int PersonId { get; set; }
        public List<Name> Names { get; set; }
        public List<DateOfBirth> DateOfBirths { get; set; }
        public List<EmailAddress> Emails { get; set; }
        public List<TelephoneNumber> Mobiles { get; set; }
        public List<TelephoneNumber> Landlines { get; set; }
        public List<Address> Addresses { get; set; }

        public Name CurrentName
        {
            get
            {
                var currentName = Names.FirstOrDefault(x => !x.Expired.HasValue);
                return currentName ?? new Name();
            }
        }

        public DateOfBirth  CurrentDateOfBirth
        {
            get
            {
                var currentDateOfBirth = DateOfBirths.FirstOrDefault(x => !x.Expired.HasValue);
                return currentDateOfBirth ?? new DateOfBirth();
            }
        }

        public EmailAddress CurrentEmailAddress
        {
            get
            {
                var currentEmailAddress = Emails.FirstOrDefault(x => !x.Expired.HasValue);
                return currentEmailAddress ?? new EmailAddress();
            }
        }

        public TelephoneNumber CurrentMobile
        {
            get
            {
                var currentMobile = Mobiles.FirstOrDefault(x => !x.Expired.HasValue);
                return currentMobile ?? new TelephoneNumber();
            }
        }

        public TelephoneNumber  CurrentLandline
        {
            get
            {
                var currentLandline = Landlines.FirstOrDefault(x => !x.Expired.HasValue);
                return CurrentLandline ?? new TelephoneNumber();
            }
        }

        public Address CurrentAddress
        {
            get
            {
                var currentAddress = Addresses.FirstOrDefault(x => !x.Expired.HasValue);
                return currentAddress ?? new Address();
            }
        }
    }
}
