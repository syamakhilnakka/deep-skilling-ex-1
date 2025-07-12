using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using YourProject.Models;
using YourProject.Filters; // ✅ Import your custom filter namespace

namespace YourProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [CustomAuthFilter] // ✅ This applies the custom authorization filter to all actions in this controller
    public class EmployeeController : ControllerBase
    {
        private List<Employee> employees;

        public EmployeeController()
        {
            employees = GetStandardEmployeeList();
        }

        private List<Employee> GetStandardEmployeeList()
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "John",
                    Salary = 50000,
                    Permanent = true,
                    Department = new Department { Id = 1, Name = "HR" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "SQL" }
                    },
                    DateOfBirth = new DateTime(1990, 01, 01)
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane",
                    Salary = 60000,
                    Permanent = false,
                    Department = new Department { Id = 2, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 3, Name = "Angular" }
                    },
                    DateOfBirth = new DateTime(1992, 05, 15)
                }
            };
        }

        [HttpGet]
        [AllowAnonymous] // ✅ This will still allow anonymous GET calls — remove this if you want filter to apply
        [ProducesResponseType(typeof(List<Employee>), 200)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Employee emp)
        {
            if (emp == null) return BadRequest("Invalid employee");
            return Ok($"Employee {emp.Name} added successfully");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Employee emp)
        {
            if (emp == null || id <= 0) return BadRequest("Invalid data");
            return Ok($"Employee {id} updated successfully");
        }
    }
}
