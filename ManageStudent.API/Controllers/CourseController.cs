using ManageStudent.Core.Models;
using ManageStudent.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManageStudent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourse()
        {
            var course = await _courseService.GetAllCourse();
            return Ok(course);
        }
    }
}
