namespace CollegeManager.Models
{
    public class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int? Grade { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
