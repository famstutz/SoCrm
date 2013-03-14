namespace SoCrm.Services.Security.Contracts
{
    using System.Collections.Generic;
    using System.ServiceModel;

    [ServiceContract]
    public interface ISecurityService
    {
        [OperationContract]
        IEnumerable<User> GetAllUsers();

        [OperationContract]
        IEnumerable<Role> GetAllRoles();

        [OperationContract]
        IEnumerable<User> GetUsersByRole(Role role);

        [OperationContract]
        bool ValidateCredentials(string userName, string password);

        [OperationContract]
        User GetUserByCredentials(string userName, string password);

        [OperationContract]
        void SetPassword(User user, string oldPassword, string newPassword);

        [OperationContract]
        void CreateUser(string userName, string password, Role role);
    }
}
