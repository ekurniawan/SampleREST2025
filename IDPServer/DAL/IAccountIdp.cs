using Microsoft.AspNetCore.Identity;

namespace IDPServer.DAL
{
    public interface IAccountIdp
    {
        Task<IdentityUser> Register(IdentityUser identityUser, string password);
        Task<IdentityUser> Login(string username, string password);
        Task<IdentityUser> GetUser(string username);
        Task<IdentityRole> GetRole(string roleName);
        Task AddRole(IdentityRole role);
        Task AddUserToRole(IdentityUser user, IdentityRole role);
        Task DeleteRole(string roleName);
    }
}
