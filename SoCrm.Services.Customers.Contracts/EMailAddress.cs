using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoCrm.Services.Customers.Contracts
{
    using SoCrm.Contracts;

    public class EMailAddress : DomainObject
    {
        public string Address { get; set; }
        public ContactType ContactType { get; set; }
    }
}
