using CollegeManager.Data;
using CollegeManager.Models;
using Microsoft.AspNetCore.Mvc;
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
                return Json(_context.Coursers.ToList());

            }
            catch (Exception ex)
            {
                Response.StatusCode = 500;
                return Json("Error: " + ex.Message);
            }
        }

        // GET: Courses/Details/5
        public JsonResult GetById(int? id)
        {
            if (id == null)
            {
                return Json("Error: Course does not exist.");
            }
            Course course = _context.Coursers.Find(id);
            if (course == null)
            {
                return Json("Course not found.");
            }
            return Json(course);
        }


        // POST: Courses/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Coursers.Add(course);
                _context.SaveChanges();
                return Json(new { success = true });
            }

            return Json(new { success = false });

        }


        // POST: Courses/Edit/5
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public JsonResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(course).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true });

            }

            return Json(new { success = false });
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
