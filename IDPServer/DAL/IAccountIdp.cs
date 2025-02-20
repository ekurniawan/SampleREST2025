using Microsoft.AspNetCore.Identity;

namespace IDPServer.DAL
{
    public interface IAccountIdp
    {
        Task<IdentityUser> Register(IdentityUser identityUser, string password);
        Task<IdentityUser> Login(string username, string password);
        Task<IdentityUser> GetUser(string username);
        Task<IdentityRole> GetRole(string roleName);
        Task<IEnumerable<string>> GetRolesFromUser(string username);
        Task AddRole(string roleName);
        Task AddUserToRole(string username, string rolename);
        Task AddRolesToUser(string username, IEnumerable<string> roles);
        Task DeleteRole(string roleName);
    }
}
