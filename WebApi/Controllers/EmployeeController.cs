using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/Emp")] // Custom route name
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<string>), 200)]
        public IActionResult GetAll()
        {
            var employees = new List<string> { "John", "Jane", "Bob" };
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public IActionResult Create([FromBody] string name)
        {
            return CreatedAtAction(nameof(GetAll), new { id = 1 }, name);
        }

        [HttpGet("find")]
        [ActionName("FindById")]
        public IActionResult GetById()
        {
            return Ok("Found employee by ID");
        }
    }
}
