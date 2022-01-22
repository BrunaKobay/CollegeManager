using System;
using System.Collections.Generic;

namespace CollegeManager.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int RegistrationId { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
