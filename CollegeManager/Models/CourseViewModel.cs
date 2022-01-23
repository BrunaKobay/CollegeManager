using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManager.Models
{
    public class CourseViewModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int TeachersCount { get; set; }
        public int StudentsCount { get; set; }
        public int GradeAvg { get; set; }


    }
}
