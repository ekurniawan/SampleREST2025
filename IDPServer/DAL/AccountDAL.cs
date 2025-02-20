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

        public async Task AddRolesToUser(string username, IEnumerable<string> roles)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(username);
                if (user != null)
                {
                    var result = await _userManager.AddToRolesAsync(user, roles);
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

        public async Task DeleteRole(string roleName)
        {
            try
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                    if (!result.Succeeded)
                    {
                        throw new ArgumentException("Role Deletion Failed !");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IdentityRole> GetRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                throw new ArgumentException("Role not found !");
            }
            return role;
        }

        public async Task<IEnumerable<string>> GetRolesFromUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new ArgumentException("User not found !");
            }
            var roles = await _userManager.GetRolesAsync(user);
            return roles;
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

        public async Task<bool> Login(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
            {
                throw new ArgumentException("User not found !");
            }
            var result = await _userManager.CheckPasswordAsync(user, password);
            if (result)
            {
                return true;
            }
            else
            {
                throw new ArgumentException("Invalid Password !");
            }
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
