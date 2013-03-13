namespace SoCrm.Contracts
{
    using System;

    public interface IDomainObject
    {
        Guid ObjectId { get; set; }
    }
}
