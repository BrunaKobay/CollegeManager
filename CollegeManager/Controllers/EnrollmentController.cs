using CollegeManager.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public ContentResult Get()
        {
            var enrollments = _context.Enrollments.ToList();

            return Content(JsonConvert.SerializeObject(enrollments, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }

        // GET: Enrollments by SubjectId
        public ContentResult GetBySubjectId(int id)
        {
            var enrollments = _context.Enrollments.Where(e => e.SubjectId == id).ToList();
            return Content(JsonConvert.SerializeObject(enrollments, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            }));
        }
    }
}
