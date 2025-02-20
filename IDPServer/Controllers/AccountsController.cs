using IDPServer.DAL;
using IDPServer.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace IDPServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountIdp _account;
        public AccountsController(IAccountIdp accountIdp)
        {
            _account = accountIdp;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(AccountRegisterDTO accountRegisterDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = accountRegisterDTO.Username,
                Email = accountRegisterDTO.Email
            };

            try
            {
                var result = await _account.Register(identityUser, accountRegisterDTO.Password);
                var responseDto = new AccountRegisterDTO
                {
                    Username = result.UserName,
                    Email = result.Email
                };
                return Ok(responseDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole(string roleName)
        {
            try
            {
                await _account.AddRole(roleName);
                return Ok("Role Added Successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string username, string rolename)
        {
            try
            {
                await _account.AddUserToRole(username, rolename);
                return Ok("User Added to Role Successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetRolesFromUser")]
        public async Task<IActionResult> GetRolesFromUser(string username)
        {
            try
            {
                var roles = await _account.GetRolesFromUser(username);
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("AddRolesToUser")]
        public async Task<IActionResult> AddRolesToUser(string username, IEnumerable<string> roles)
        {
            try
            {
                await _account.AddRolesToUser(username, roles);
                return Ok("Roles Added to User Successfully !");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
