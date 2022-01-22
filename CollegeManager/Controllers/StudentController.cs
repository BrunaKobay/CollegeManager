using CollegeManager.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Text.Json;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CollegeManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly DataContext _context;

        public StudentController(DataContext context)
        {
            _context = context;
        }

        // GET: Subjects
        //public ContentResult Get()
        //{
        //    try
        //    {
        //        var subjects = _context.Subjects.Include(s => s.Course).Include(s => s.Teacher).ToList();

        //        return Content(JsonConvert.SerializeObject(subjects, new JsonSerializerSettings()
        //        {
        //            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        //        }));

        //    }
        //    catch (Exception ex)
        //    {
        //        Response.StatusCode = 500;
        //        //return Content(JsonConvert.SerializeObject(JsonConvert.SerializeObject(new { error_message = "Error: " + ex.Message })));
        //        return Content(JsonConvert.SerializeObject(ex));
        //    }
        //}
        // GET: Students

        [HttpGet]
        public ContentResult Get()
        {
            try
            {
                return Content(JsonConvert.SerializeObject(_context.Students.ToList(), new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                }));
            }
            catch (Exception ex)
            {

                return Content(JsonConvert.SerializeObject(ex));
            }
        }

    }
}
