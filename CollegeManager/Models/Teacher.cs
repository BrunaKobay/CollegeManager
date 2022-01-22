using System;
using System.Collections.Generic;

namespace CollegeManager.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public double Salary { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
