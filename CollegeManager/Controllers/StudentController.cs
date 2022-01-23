using CollegeManager.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using CollegeManager.Models;

namespace CollegeManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;
        //private readonly DataContext _context = new DataContext("DefaultConn");

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET: Students
        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                return Json(_context.Students.ToList(), new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
            }
            catch (Exception ex)
            {

                return Json(new { error = ex.Message });
            }
        }

        // GET: Student/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody]Student students)
        {
            try
            {
                _context.Students.Add(students);
                _context.SaveChanges();
                return Json(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }

        // POST: Student/Edit/Id
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]Student student)
        {

            try
            {
                var confirm = _context.Students.AsNoTracking().Where(s => s.Id == student.Id).SingleOrDefault();
                if (confirm == null) { return Json(new { error = "Something went wrong!" }); }


                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }


        // GET: Student/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var student = _context.Students.Find(id);
                if (student == null) { return Json(new { error = "Something went wrong." }); }

                _context.Students.Remove(student);
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
