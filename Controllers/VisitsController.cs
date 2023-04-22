using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VisitsController : ControllerBase
    {
        private readonly IRepository<Visit> _visitRepository;
        public VisitsController(IRepository<Visit> visitRepository)
        {
            _visitRepository = visitRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(new { message = "OK", response = _visitRepository.Get() });
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
                Visit visit = _visitRepository.Get(id);
                if (visit == null)
                    return NotFound();

                return Ok(new { message = "OK", response = visit });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Visit visit)
        {
            try
            {
                _visitRepository.Update(visit);
                _visitRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Visit visit)
        {
            try
            {
                _visitRepository.Update(visit);
                _visitRepository.Save();
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
                _visitRepository.Delete(id);
                _visitRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
