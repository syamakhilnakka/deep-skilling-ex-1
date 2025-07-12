using System;

namespace StudentApiApp.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Course Course { get; set; }
    }
}
