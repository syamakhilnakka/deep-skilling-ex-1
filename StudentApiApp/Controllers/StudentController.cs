using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StudentApiApp.Models;

namespace StudentApiApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Alice", Age = 20, Course = new Course { Id = 101, Title = "Math" } },
            new Student { Id = 2, Name = "Bob", Age = 22, Course = new Course { Id = 102, Title = "Physics" } }
        };

        [HttpGet]
        public ActionResult<List<Student>> Get()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult<Student> GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");
            return Ok(student);
        }

        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student newStudent)
        {
            if (newStudent == null)
                return BadRequest("Invalid input");

            newStudent.Id = students.Max(s => s.Id) + 1;
            students.Add(newStudent);
            return CreatedAtAction(nameof(GetById), new { id = newStudent.Id }, newStudent);
        }

        [HttpPut("{id}")]
        public ActionResult<Student> Put(int id, [FromBody] Student updatedStudent)
        {
            if (id <= 0 || updatedStudent == null)
                return BadRequest("Invalid student id");

            var existing = students.FirstOrDefault(s => s.Id == id);
            if (existing == null)
                return NotFound("Student not found");

            existing.Name = updatedStudent.Name;
            existing.Age = updatedStudent.Age;
            existing.Course = updatedStudent.Course;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);
            return Ok($"Student with id {id} deleted.");
        }
    }
}
