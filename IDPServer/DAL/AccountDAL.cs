using Microsoft.AspNetCore.Identity;

namespace IDPServer.DAL
{
    public class AccountDAL : IAccountIdp
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountDAL(UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public Task AddRole(IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task AddUserToRole(IdentityUser user, IdentityRole role)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> GetRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> GetUser(string username)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityUser> Login(string username, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> Register(IdentityUser identityUser, string password)
        {
            try
            {
                var result = await _userManager.CreateAsync(identityUser, password);
                if (result.Succeeded)
                {
                    return identityUser;
                }
                else
                {
                    throw new ArgumentException("User Registration Failed !");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
