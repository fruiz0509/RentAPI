using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IRepository<User> _userRepository;
        public UsersController(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(new { message = "OK", response = _userRepository.Get() });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            User user = _userRepository.Get(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(new { message = "OK", response = user });
        }

        [HttpPost]
        public IActionResult Post([FromBody] User user) 
        {
            try
            {
                _userRepository.Add(user);
                _userRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] User user)
        {
            try
            {
                _userRepository.Update(user);
                _userRepository.Save();
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
                _userRepository.Delete(id);
                _userRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
