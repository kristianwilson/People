using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace People.Core.Objects
{
    public class Name
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime? Expired { get; set; }
        public string Fullname { get { return string.Format("{0} {1}", Firstname, Surname); } }
    }
}
