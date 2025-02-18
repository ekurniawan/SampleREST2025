using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleREST.Services.DAL;
using SampleREST.Services.Models;

namespace SampleREST.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICourse _course;
        public CoursesController(ICourse course)
        {
            _course = course;
        }

        /*[HttpGet]
        public IEnumerable<ViewCourseWithCategory> Get()
        {
            var results = _course.GetAllCourse();
            return results;
        }*/

        [HttpGet]
        public IEnumerable<Course> Get()
        {
            var results = _course.GetAllCourses();
            return results;
        }


    }
}
