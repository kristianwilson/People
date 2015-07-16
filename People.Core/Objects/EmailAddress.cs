using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Objects
{
    public class EmailAddress
    {
        public string Value { get; set; }
        public bool DoNotUse { get; set; }
        public DateTime? Expired { get; set; }
    }
}
