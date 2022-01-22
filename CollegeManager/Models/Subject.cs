using System.Collections.Generic;

namespace CollegeManager.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
