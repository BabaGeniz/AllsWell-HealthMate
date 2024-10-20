using Microsoft.AspNetCore.Mvc;
using AllsWellHealthMate.DTOs;
using AllsWellHealthMate.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AllsWellHealthMate.Repositories;

namespace AllsWellHealthMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IUserRepository _userRepository;

        public AuthController(IConfiguration configuration, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLoginDTO loginDto) 
        {
            var user = _userRepository.GetAllUsers()
                                      .Where(u => u.Email == loginDto.Email && u.Password == loginDto.Password)
                                      .FirstOrDefault();
            if ( user != null)
            {
                var token = GenerateJwtToken(loginDto.Email,user.UserRole,user.Id);
                return Ok(new { token });
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(string email, string role, int userId)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = Encoding.ASCII.GetBytes(jwtSettings.GetValue<string>("SecretKey"));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),               // Email claim
                    new Claim(ClaimTypes.NameIdentifier, userId.ToString()),  // User ID claim (as sub or nameidentifier)
                    new Claim(ClaimTypes.Role, role)                  // User role claim
                }),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.GetValue<int>("ExpirationInMinutes")),
                Issuer = jwtSettings.GetValue<string>("Issuer"),
                Audience = jwtSettings.GetValue<string>("Audience"),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
