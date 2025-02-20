using IDPServer.DAL;
using IDPServer.DTO;
using IDPServer.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IDPServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountIdp _account;
        private readonly AppSettings _appSettings;

        public AccountsController(IAccountIdp accountIdp, IOptions<AppSettings> appSettings)
        {
            _account = accountIdp;
            _appSettings = appSettings.Value;
        }


        [AllowAnonymous]
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


        [Authorize(Roles = "superadmin")]
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

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            try
            {
                var result = await _account.Login(loginDTO.Username, loginDTO.Password);
                if (!result)
                {
                    return BadRequest("Invalid Username or Password !");
                }

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, loginDTO.Username));
                var roles = await _account.GetRolesFromUser(loginDTO.Username);
                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddHours(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var accountDto = new AccountDTO
                {
                    Username = loginDTO.Username,
                    Token = tokenHandler.WriteToken(token)
                };
                return Ok(accountDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
