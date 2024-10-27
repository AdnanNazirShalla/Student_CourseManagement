using Microsoft.AspNetCore.Mvc.Rendering;
using Student_CourseManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.RRModels
{
    public class StudentCourseRequest
    {
        public List<StudentResponse> students { get; set; } = new();

        public List<SelectListItem> courses { get; set; } = new();
    }

    public class StudentCourseResponse
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }

        [DisplayName("Name")]
        public string StudentName { get; set; }

        [DisplayName("Course")]
        public string CourseName { get; set; }

    }
}
