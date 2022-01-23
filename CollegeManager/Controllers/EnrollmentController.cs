using CollegeManager.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CollegeManager.Models;

namespace CollegeManager.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly DataContext _context;

        public EnrollmentController(DataContext context)
        {
            _context = context;
        }

        // GET: Enrollments
        public JsonResult Get()
        {
            var enrollments = _context.Enrollments.ToList();

            return Json(enrollments, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET: Enrollments by SubjectId
        public JsonResult GetBySubjectId(int id)
        {
            var enrollments = _context.Enrollments.Include(s => s.Student).Where(e => e.SubjectId == id).ToList();
            return Json(enrollments, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET: Enrollments by StudentId
        public JsonResult GetByStudentId(int id)
        {
            var enrollments = _context.Enrollments.Include(s => s.Subject).Where(e => e.StudentId == id).ToList();
            return Json(enrollments, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        // GET: Enrollment/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody] Enrollment enrollment)
        {
            try
            {
                _context.Enrollments.Add(enrollment);
                _context.SaveChanges();
                return Json(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }

        // POST: Enrollment/Edit/Id
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]Enrollment enrollment)
        {

            try
            {
                var confirm = _context.Enrollments.AsNoTracking().Where(e => e.EnrollmentId == enrollment.EnrollmentId).SingleOrDefault();
                if (confirm == null) { return Json(new { error = "Invalid Id" }); }

                _context.Entry(enrollment).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }

        // POST: Enrollment/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var enrollment = _context.Enrollments.Find(id);
                if (enrollment == null) { return Json(new { error = "Invalid Id" }); }

                _context.Enrollments.Remove(enrollment);
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }
    }
}
