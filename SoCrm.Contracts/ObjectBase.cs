namespace SoCrm.Contracts
{
    using System;

    public class ObjectBase : IDomainObject
    {
        public Guid ObjectId { get; set; }
    }
}
