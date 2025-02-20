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

        public async Task AddRole(string roleName)
        {
            try
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!result.Succeeded)
                    {
                        throw new ArgumentException("Role Creation Failed !");
                    }
                }
                else
                {
                    throw new ArgumentException("Role Already Exist !");
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public async Task AddUserToRole(string username, string rolename)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var roleExist = await _roleManager.RoleExistsAsync(rolename);
                    if (!roleExist)
                    {
                        throw new ArgumentException("Role Not Found !");
                    }
                    var result = await _userManager.AddToRoleAsync(user, rolename);
                    if (!result.Succeeded)
                    {
                        throw new ArgumentException("User Role Assignment Failed !");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task DeleteRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityRole> GetRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityUser> GetUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new ArgumentException("User not found !");
            }
            return user;
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
