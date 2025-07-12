using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentApiAuthApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace StudentApiAuthApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin,POC")]
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

        [HttpPost]
        public ActionResult<Student> Post([FromBody] Student student)
        {
            student.Id = students.Max(s => s.Id) + 1;
            students.Add(student);
            return CreatedAtAction(nameof(Get), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Student updatedStudent)
        {
            var existing = students.FirstOrDefault(s => s.Id == id);
            if (existing == null) return NotFound("Student not found");

            existing.Name = updatedStudent.Name;
            existing.Age = updatedStudent.Age;
            existing.Course = updatedStudent.Course;

            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null) return NotFound("Student not found");

            students.Remove(student);
            return Ok($"Student {id} deleted.");
        }
    }
}
