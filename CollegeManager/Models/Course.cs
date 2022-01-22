using System.Collections.Generic;

namespace CollegeManager.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
