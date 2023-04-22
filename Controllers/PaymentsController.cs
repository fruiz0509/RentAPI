using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentAPI.Models;
using RentAPI.Repository;

namespace RentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IRepository<Payment> _paymentRepository;
        public PaymentsController(IRepository<Payment> paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            try
            {
                return Ok(new { message = "OK", response = _paymentRepository.Get() });
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
                Payment payment = _paymentRepository.Get(id);
                if (payment == null)
                {
                    return NotFound();
                }

                return Ok(new { message = "OK", response = payment });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody] Payment payment) 
        {
            try
            {
                _paymentRepository.Update(payment);
                _paymentRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Payment payment)
        {
            try
            {
                _paymentRepository.Update(payment);
                _paymentRepository.Save();
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
                _paymentRepository.Delete(id);
                _paymentRepository.Save();
                return Ok(new { message = "OK" });
            }
            catch (Exception ex)
            {
                return Ok(new { message = ex.Message });
            }
        }
    }
}
