using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;
using System.Security.Claims;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRepository<Role> _roleRepository;

        public RolesController(IRepository<Role> roleRepository)
        {
            _roleRepository = roleRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            bool validate = ValidateToken();
            if (!validate)
            {
                return Ok(new 
                {
                    success = false,
                    message = "Permisos insuficientes",
                    result = ""
                });
            }

            try
            {
                return Ok(new { message = "OK", response = _roleRepository.Get() });
            }
            catch (Exception ex)
            {
                return Ok( new { message = ex.Message});
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Role role = _roleRepository.Get(id);
                if (role == null)
                {
                    return NotFound();
                }
                return Ok(new { message =  "OK", response = role });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            try
            {
                _roleRepository.Add(role);
                _roleRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Role role)
        {
            try
            {
                _roleRepository.Update(role);
                _roleRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _roleRepository.Delete(id);
                _roleRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        public bool ValidateToken()
        { 
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var token = Jwt.ValidarToken(identity);

            if (!token.success) return token;

            User user = token;
            if (user.Id != 1)
            {
                return false;
            }

            return true;
        }
    }
}
