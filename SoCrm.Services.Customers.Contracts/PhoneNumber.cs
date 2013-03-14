using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoCrm.Services.Customers.Contracts
{
    using SoCrm.Contracts;

    public class PhoneNumber : DomainObject
    {
        public string Number { get; set; }
        public ContactType ContactType { get; set; }
    }
}
