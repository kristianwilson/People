using System;

namespace People.Core.Objects
{
    public class EmailAddress
    {
        public int EmailAddressId { get; set; }
        public string Email { get; set; }
        public EmailAddressType EmailAddressType { get; set; }

        public bool DoNotUse { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public EmailAddress()
        {
            EmailAddressId = 0;
            Email = string.Empty;
            EmailAddressType = EmailAddressType.Unknown;
            
            DoNotUse = true;
            FromDate = DateTime.Today;
            ToDate = null;
        }
    }
}
