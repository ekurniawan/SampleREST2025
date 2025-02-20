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
    }
}
