using Microsoft.AspNetCore.Mvc;
using Student_CourseManagement.Application.Abstraction.IServices;
using Student_CourseManagement.Application.RRModels;

namespace Student_CourseManagement.API.Controllers
{
    //[Route("students")]
    public class StudentsController : Controller
    {
        private readonly IStudentServices services;

        public StudentsController(IStudentServices services)
        {
            this.services = services;
        }
        [HttpGet("add")]
        public IActionResult AddStudent()
        {
            return View();
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddStudent(StudentRequest model)
        {
            if (ModelState.IsValid)
            {
                int res = await services.AddStudent(model);

                if (res == 1)
                {
                    TempData["Success"] = "Student Added Successfully";
                    return RedirectToAction(nameof(GetStudents));
                }
                else if (res == 0)
                {
                    TempData["Error"] = "There is some error please try after sometime";
                }
                else
                {
                    TempData["Error"] = "User already exists";
                }
                return View();
            }

            return View(model);
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            return View(await services.GetStudentById(id));
        }

        [HttpGet("")]
        public async Task<IActionResult> GetStudents()
        {
            var students = await services.GetAllStudents();
            if (students is not null)
            {
                return View(students);
            }
            return View();
        }

        [HttpGet("update/{id}")]
        public async Task<IActionResult> UpdateStudent(Guid id)
        {
            var student = await services.GetStudentById(id);
            if (student is not null)
            {
                return View(student);
            }
            return View();
        }

        [HttpPost("update/{id}")]
        public async Task<IActionResult> UpdateStudent(StudentUpdateRequest model)
        {
            var res = await services.UpdateStudent(model);

            if (res == 1)
            {
                TempData["Success"] = "Student updated successfully";
                return RedirectToAction(nameof(GetStudents));
            }

            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
            return View();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DeleteStudent(Guid id)
        {
            var res = await services.DeleteStudent(id);
            if (res == 1)
            {
                TempData["Success"] = "Student Deleted successfully";
                
            }

            else
            {
                TempData["Error"] = "There is some error please try after sometime";
            }
           return RedirectToAction(nameof(GetStudents));

        }
        
    }
}
