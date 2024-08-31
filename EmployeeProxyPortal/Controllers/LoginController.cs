using EmployeeProxyPortal.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EmployeeProxyPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _configuration;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IConfiguration configuration, ILogger<LoginController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        private User AuthenticateUser(User user)
        {
            _logger.LogInformation("Authentication for user started");
            User _user = null;
            if (user.UserName == "InTimeTec" && user.Password == "ITT@123456")
            {
                _user = new User { UserName = "InTimeTec" };
            }

            return _user;
        }

        private string GenerateToken(User user)
        {
            _logger.LogInformation("Generating token for the user");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"],
                claims, expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(User users)
        {
            IActionResult response = Unauthorized();
            _logger.LogInformation("Login method statred");
            var user = AuthenticateUser(users);
            if (user != null)
            {
                var token = GenerateToken(user);
                response = Ok(new { token });
            }
            return response;
        }
    }
}
