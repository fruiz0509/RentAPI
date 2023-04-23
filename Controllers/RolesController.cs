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
        private readonly Jwt _jwt;

        public RolesController(IRepository<Role> roleRepository, Jwt jwt)
        {
            _roleRepository = roleRepository;
            _jwt = jwt;
        }

        private dynamic ValidateUserRol()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            var token = _jwt.ValidarToken(identity);

            if (!token.success) return token;

            User user = token.result;
            if (user.Id != 1)
            {
                return new
                {
                    success = false,
                    message = "No tienes permisos",
                    response = ""
                };
            }

            return new
            {
                success = true,
                message = "Acceso concedido",
                response = ""
            };
        }

        [HttpGet]
        public IActionResult Get() 
        {

            var response = ValidateUserRol();
            if (!response.success)
            {
                return Ok(new { success = true, message = "No tienes permisos", response = "" });
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
            var response = ValidateUserRol();
            if (!response.success)
            {
                return Ok(new { success = true, message = "No tienes permisos", response = "" });
            }

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
            var response = ValidateUserRol();
            if (!response.success)
            {
                return Ok(new { success = true, message = "No tienes permisos", response = "" });
            }

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
            var response = ValidateUserRol();
            if (!response.success)
            {
                return Ok(new { success = true, message = "No tienes permisos", response = "" });
            }

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
            var response = ValidateUserRol();
            if (!response.success)
            {
                return Ok(new { success = true, message = "No tienes permisos", response = "" });
            }

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

    }
}
