﻿using Microsoft.AspNetCore.Http;
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
        private readonly Jwt _jwt;

        public RolesController(IRepository<Role> roleRepository, Jwt jwt)
        {
            _roleRepository = roleRepository;
            _jwt = jwt;
        }

        [HttpGet]
        public IActionResult Get() 
        {
            
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
    }
}
