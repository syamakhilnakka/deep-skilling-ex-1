using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FirstWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var data = new List<string> { "value1", "value2" };
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0) return BadRequest("Invalid ID");
            return Ok($"Value {id}");
        }

        [HttpPost]
        public IActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return BadRequest("Value is required");
            return CreatedAtAction(nameof(Get), new { id = 1 }, value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string value)
        {
            if (id <= 0) return BadRequest("Invalid ID");
            return Ok($"Updated ID {id} with value: {value}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (id <= 0) return NotFound("ID not found");
            return Ok($"Deleted ID {id}");
        }
    }
}
