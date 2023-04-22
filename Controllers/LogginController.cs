using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
//using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using RentAPI.Models;
using RentAPI.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogginController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        private readonly IConfiguration _configuration;
        public LogginController(IRepository<User> userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        [HttpPost]
        public dynamic LogIn([FromBody] Object credentials)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(credentials.ToString());

            string email = data.email.ToString();
            string password = data.pass.ToString();

            User user = _userRepository.Get().Where(x => x.Email == email && x.Pass == password).FirstOrDefault();

            if (user == null)
            {
                return new
                {
                    success = false,
                    message = "Credenciales incorrectas",
                    result = "",
                };
            }

            var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("id", user.Id.ToString()),
                new Claim("usuario", user.FirstName + " " + user.LastName),
                new Claim("email", user.Email),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwt.Key));
            var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: signin
                );

            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }
    }
}
