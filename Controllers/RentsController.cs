using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RentsController : ControllerBase
    {
        private readonly IRepository<Rent> _rentRepository;
        public RentsController(IRepository<Rent> rentRepository)
        {
            _rentRepository = rentRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(new { message = "OK", response = _rentRepository.Get() });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                Rent rent = _rentRepository.Get(id);
                if(rent == null)
                    return NotFound();

                return Ok(new { message = "OK", response = rent });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Rent rent) 
        {
            try
            {
                _rentRepository.Add(rent);
                _rentRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Rent rent)
        {
            try
            {
                _rentRepository.Update(rent);
                _rentRepository.Save();
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
                _rentRepository.Delete(id);
                _rentRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
