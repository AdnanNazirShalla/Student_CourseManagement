using Microsoft.AspNetCore.Mvc;
using Student_CourseManagement.Application.Abstraction.IServices;
using Student_CourseManagement.Application.RRModels;

namespace Student_CourseManagement.API.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {
        private readonly ICourseServices services;

        public CoursesController(ICourseServices services)
        {
            this.services = services;
        }

        [HttpGet("add")]
        public async Task<IActionResult> AddCourse()
        {
            return View();
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddCourse(CourseRequest model)
        {
            var res = await services.AddCourse(model);

            if (res == 1)
            {
                TempData["Success"] = "Course Added Successfully";
                return RedirectToAction(nameof(GetCourses));
            }
            else if (res ==0)
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
            else
            {
                TempData["Error"] = "Course already exists";
            }
            return View();
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCourses()
        {
            return View(await services.GetAllCouurses());
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateCourse(Guid id)
        {
            return View(await services.GetCourseById(id));
        }
        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateCourse(UpdateCourseRequest model)
        {
            var res = await services.UpdateCourse(model);

            if (res == 1)
            {
                TempData["Success"] = "Course updated successfully";
                return RedirectToAction(nameof(GetCourses));
            }
            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var res = await services.DeleteCourse(id);

            if (res ==1)
            {
                TempData["Success"] = "Course Deleted Successfully";
            }
            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
           return RedirectToAction(nameof(GetCourses));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
