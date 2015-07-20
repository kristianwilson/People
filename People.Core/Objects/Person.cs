using System;

namespace People.Core.Objects
{
    public class Person
    {
        public int PersonId { get; set; }
        public Guid PersonUid { get; set; }
        public GenderType Gender { get; set; }
        
        public Name Name { get; set; }
        public EmailAddress Email { get; set; }
        public TelephoneNumber Mobile { get; set; }
        public TelephoneNumber Landline { get; set; }
        public Address Address { get; set; }

        public DateTime DateOfBirth { get; set; }
        public DateTime? DeathDate { get; set; }
        public bool Blacklisted { get; set; }

        public Person()
        {
            PersonId = 0;
            PersonUid = Guid.Empty;

            Name = new Name();
            Email = new EmailAddress();
            Mobile = new TelephoneNumber();
            Landline = new TelephoneNumber();
            Address = new Address();

            DateOfBirth = DateTime.Now;
            DeathDate = null;
            Blacklisted = false;
        }
    }
}
