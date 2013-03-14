namespace SoCrm.Services.Contacts.Contracts
{
    using System;

    using SoCrm.Contracts;
    using SoCrm.Services.Customers.Contracts;
    using SoCrm.Services.Security.Contracts;

    public class Contact : DomainObject
    {
        User User { get; set; }
        Person Person { get; set; }
        string Content { get; set; }
        ContactMedium Medium { get; set; }
        DateTime DateTime { get; set; }
    }
}
