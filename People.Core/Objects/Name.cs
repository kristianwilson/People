using System;

namespace People.Core.Objects
{
    public class Name
    {
        public int NameId { get; set; }
        public Title Title { get; set; }
        public string GivenName { get; set; }
        public string AdditionalName { get; set; }
        public string FamilyName { get; set; }
        public string KnownAs { get; set; }

        public bool DoNotuse { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        
        public Name()
        {
            NameId = 0;
            Title = Title.Unknown;
            GivenName = string.Empty;
            AdditionalName = string.Empty;
            FamilyName = string.Empty;
            KnownAs = string.Empty;
            
            DoNotuse = false;
            FromDate = DateTime.Today;
            ToDate = null;
        }
    }
}
