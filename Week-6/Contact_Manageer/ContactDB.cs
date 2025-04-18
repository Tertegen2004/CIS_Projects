using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contact_Manageer
{
    public interface IContactDB
    {
        public List<Contact> Contacts { get; set; }

    }
}
