namespace SoCrm.Contracts
{
    using System;

    public interface IDomainObject
    {
        Guid ObjectId { get; set; }
        DateTime CreationTimeStamp { get; set; }
        DateTime LastUpdateTimeStamp { get; set; }
    }
}
