using CollegeManager.Data;
using CollegeManager.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace CollegeManager.Controllers
{
    public class CourseController : Controller
    {
        private readonly DataContext _context;

        public CourseController(DataContext context)
        {
            _context = context;
        }

        // GET: Courses
        public JsonResult Get()
        {
            try
            {
                var courses = _context.Coursers.Include(s => s.Subjects).ToList();
                return Json(courses, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }

        // GET: Courses/Details/5
        public JsonResult GetById(int? id)
        {
            if (id == null)
            {
                return Json(new { error = "Error: Course does not exist." });
            }
            Course course = _context.Coursers.Find(id);
            if (course == null)
            {
                return Json(new { error = "Course not found." });
            }
            return Json(course);
        }

        // GET: Courses/Details
        public JsonResult GetDetails()
        {
            var allCollegeDetails = (from e in _context.Enrollments.AsNoTracking().ToList()
                                     join s in _context.Subjects on e.SubjectId equals s.Id
                                     join c in _context.Coursers on s.CourseId equals c.Id
                                     join t in _context.Teachers on s.TeacherId equals t.Id
                                     select new {  
                                         CourseId = c.Id, 
                                         SubjectId = s.Id, 
                                         TeacherId = t.Id,
                                         StudentId = e.StudentId,
                                         StudentGrade = e.Grade
                                     }).ToList();


            List<CourseViewModel> courseDetailsList = new List<CourseViewModel>();
            foreach (var course in _context.Coursers.ToList())
            {
                var courseDetail = new CourseViewModel();
                courseDetail.CourseId = course.Id;
                courseDetail.CourseName = course.Name;
                courseDetail.TeachersCount = allCollegeDetails.Where(a => a.CourseId == course.Id).Select(s => s.TeacherId).Distinct().Count();
                courseDetail.StudentsCount = allCollegeDetails.Where(a => a.CourseId == course.Id).Select(s => s.StudentId).Distinct().Count();
                courseDetail.GradeAvg = allCollegeDetails.Where(a => a.CourseId == course.Id).Select(s => s.StudentGrade).DefaultIfEmpty(defaultValue: 0).Average();

                courseDetailsList.Add(courseDetail);
            }


            return Json(courseDetailsList);
        }

        // GET: Courses/Details
        public JsonResult GetSumDetails()
        {


            var totalCount = new Dictionary<string, double>()    {
                { "totalCourse", _context.Coursers.Distinct().Count() },
                { "totalSubjects", _context.Subjects.Distinct().Count() },
                { "totalStudents", _context.Students.Distinct().Count() },
                { "totalTeachers", _context.Teachers.Distinct().Count() }
            };


            return Json(totalCount);
        }



        // POST: Courses/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody]Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Coursers.Add(course);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { error = "Something went wrong." });


        }


        // POST: Courses/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            return Json(new { error = "Something went wrong." });
            
        }


        // POST: Courses/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Delete(int id)
        {
            Course course = _context.Coursers.Find(id);
            _context.Coursers.Remove(course);
            _context.SaveChanges();
            return Json(new { success = true });
        }


    }
}
