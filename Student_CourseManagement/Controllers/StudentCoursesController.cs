using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_CourseManagement.Application.Abstraction.IServices;

namespace Student_CourseManagement.API.Controllers
{
    [Route("student-course")]
    public class StudentCoursesController : Controller
    {
        private readonly IStudentCourseServices services;

        public StudentCoursesController(IStudentCourseServices services)
        {
            this.services = services;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetStudentCourse()
        
        {
            var studentCourse=await services.GetAllCourses();
            
            return View(studentCourse);
        }
        [HttpPost("add/{id}")]
        public async Task<IActionResult> AddStudentCourse(Guid id,Guid CourseId)
        {
           var res = await services.AddStudentCourse(id,CourseId);
            if (res == 1)
            {
                TempData["Success"] = "Student Enrolled Successfully";
            }
            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
            return RedirectToAction(nameof(GetStudentCourse));
        }

        [HttpGet("course/{id}")]
        public async Task<IActionResult> GetStudentsByCourseId(Guid id)
        {
            var res =await services.GetStudentCourses(id);
            return View(res);
        }
        [HttpGet("delete/{id}")]
        public async Task<IActionResult> DeleteStudentFromCourse(Guid id)
        {
            var res = await services.DeleteStudentFromCourse(id);
            if (res == 1)
            {
                TempData["Success"] = "Student Removed Successfully";
            }
            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
            return RedirectToAction(nameof(GetStudentCourse));
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllStudentsInCourses()
        {
            return View(await services.GetAllStudentsInCourses());
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}
