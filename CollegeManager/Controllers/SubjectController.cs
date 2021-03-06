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
    public class SubjectController : Controller
    {
        private readonly DataContext _context;

        public SubjectController(DataContext context)
        {
            _context = context;
        }

        // GET: Subjects
        public JsonResult Get()
        {
            try
            {
                var subjects = _context.Subjects.Include(c => c.Course).Include(t => t.Teacher).ToList();

                return Json(subjects, new JsonSerializerSettings()
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


        // GET: Subjects/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create([FromBody]Subject subjects)
        {
            try
            {
                _context.Subjects.Add(subjects);
                _context.SaveChanges();
                return Json(new { Status = "Ok" });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }



        // POST: Subject/Edit/Id
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Edit([FromBody]Subject subject)
        {

            try
            {
                var confirm = _context.Subjects.AsNoTracking().Where(s => s.Id == subject.Id).SingleOrDefault();
                if (confirm == null) { return Json(new { error = "Invalid Id" }); }

                _context.Entry(subject).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json(new { error = ex.Message });
            }

        }


        // GET: Subject/Delete/5
        [HttpPost]
        public JsonResult Delete(int? id)
        {
            try
            {
                var subject = _context.Subjects.Find(id);
                if (subject == null) { return Json(new { error = "Invalid Id" }); }

                _context.Subjects.Remove(subject);
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
