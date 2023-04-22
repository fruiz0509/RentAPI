using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message = "OK", response = _roleRepository.Get() });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message, response = _roleRepository.Get() });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Role role = _roleRepository.Get(id);
            if(role == null)
            {
                return NotFound();
            }

            try
            {
                return StatusCode(StatusCodes.Status200OK, new { message =  "OK", response = role });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            try
            {
                _roleRepository.Add(role);
                _roleRepository.Save();
                return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Role role)
        {
            try
            {
                _roleRepository.Update(role);
                _roleRepository.Save();
                return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _roleRepository.Delete(id);
                _roleRepository.Save();
                return StatusCode(StatusCodes.Status200OK, new { message = "OK" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { message = ex.Message });
            }
        }
    }
}
