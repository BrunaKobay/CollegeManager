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
        public ContentResult Get()
        {
            try
            {
                var teachers = _context.Teachers.ToList();
                return Content(JsonConvert.SerializeObject(teachers, new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Content(JsonConvert.SerializeObject(JsonConvert.SerializeObject(new { error_message = "Error: " + ex.Message })));
            }
        }


        // POST: Teacher/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(Teacher teacher)
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
                return Json(new { error_message = "Error: " + ex.Message });
            }

        }



        // POST: Teacher/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit(Teacher teacher)
        {

            try
            {
                var confirm = _context.Teachers.AsNoTracking().Where(s => s.Id == teacher.Id).SingleOrDefault();
                if (confirm == null) { return Json(new { success = false }); }

                _context.Entry(teacher).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message });
            }

        }

        // GET: Teacher/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var teacher = _context.Teachers.Find(id);
                if (teacher == null) { return Json(new { success = false }); }

                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error_message = "Error: " + ex.Message });
            }

        }



    }
}
