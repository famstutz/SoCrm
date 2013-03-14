namespace SoCrm.Services.Security.Contracts
{
    using SoCrm.Contracts;

    public class User : DomainObject
    {
        public string UserName { get; set; }
        public Role Role { get; set; }
        public string Password { get; set; }
    }
}
