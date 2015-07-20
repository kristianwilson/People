using System;

namespace People.Core.Objects
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string AddressLine4 { get; set; }
        public string Postcode { get; set; }
        public string County { get; set; }
        public string CountryCode { get; set; }
        public string Udprn { get; set; }

        public AddressType AddressType { get; set; }
        public bool DoNotUse { get; set; }
        public bool Owned { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public Address()
        {
            AddressId = 0;
            AddressLine1 = string.Empty;
            AddressLine2 = string.Empty;
            AddressLine3 = string.Empty;
            AddressLine4 = string.Empty;
            Postcode = string.Empty;
            County = string.Empty;
            CountryCode = string.Empty;
            Udprn = string.Empty;

            AddressType = AddressType.Unknown;
            DoNotUse = false;
            Owned = false;
            FromDate = DateTime.Today;
            ToDate = null;
        }
    }
}
