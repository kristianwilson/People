using System;
using System.Collections.Generic;

namespace People.Core.Objects
{
    public class PersonWithHistory
    {
        public int PersonId { get; set; }
        public Guid PersonUid { get; set; }
        public GenderType Gender { get; set; }

        public List<Name> Names { get; set; }
        public List<EmailAddress> Emails { get; set; }
        public List<TelephoneNumber> Mobiles { get; set; }
        public List<TelephoneNumber> Landlines { get; set; }
        public List<Address> Addresses { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime? DeathDate { get; set; }
        public bool Blacklisted { get; set; }

        public PersonWithHistory()
        {
            PersonId = 0;
            PersonUid = Guid.Empty;

            Names = new List<Name>();
            Emails = new List<EmailAddress>();
            Mobiles = new List<TelephoneNumber>();
            Landlines = new List<TelephoneNumber>();
            Addresses = new List<Address>();

            DateOfBirth = DateTime.Now;
            DeathDate = null;
            Blacklisted = false;
        }
    }
}
