using System;

namespace People.Core.Objects
{
    public class TelephoneNumber
    {
        public int TelephoneNumberId { get; set; }
        public TelephoneType TelephoneType { get; set; }
        public string Number {get;set;}
        public TelephoneNumberType TelephoneNumberType { get; set; }

        public bool DoNotUse { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        public TelephoneNumber()
        {
            TelephoneNumberId = 0;
            TelephoneType = TelephoneType.Unknown;
            Number = string.Empty;
            TelephoneNumberType = TelephoneNumberType.Unknown;

            DoNotUse = false;
            FromDate = DateTime.Now;
            ToDate = null;
        }
    }
}
