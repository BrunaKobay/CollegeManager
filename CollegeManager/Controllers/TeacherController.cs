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
    public class TeacherController : Controller
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
            _context = context;
        }

        // GET: Teacher
        public JsonResult Get()
        {
            try
            {
                var teachers = _context.Teachers.Include(s => s.Subjects).ToList();
                return Json(teachers, new JsonSerializerSettings()
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

        // GET: Teacher/details
        public JsonResult GetbyId(int id)
        {
            try
            {
                var teacher = _context.Teachers.Include(s => s.Subjects).Where(t => t.Id == id);
                return Json(teacher, new JsonSerializerSettings()
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

        // POST: Teacher/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody]Teacher teacher)
        {
            try
            {
                _context.Teachers.Add(teacher);
                _context.SaveChanges();
                return Json(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }



        // POST: Teacher/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]Teacher teacher)
        {

            try
            {
                var confirm = _context.Teachers.AsNoTracking().Where(s => s.Id == teacher.Id).SingleOrDefault();
                if (confirm == null) { return Json(new { error = "Something went wrong!" }); }

                _context.Entry(teacher).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }

        // GET: Teacher/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var teacher = _context.Teachers.Find(id);
                if (teacher == null) { return Json(new { error = "Something went wrong!" }); }

                _context.Teachers.Remove(teacher);
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
