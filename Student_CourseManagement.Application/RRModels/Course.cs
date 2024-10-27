using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.RRModels
{
    public class CourseRequest
    {
        [Required(ErrorMessage ="Enter course Name!"),DisplayName("Course")]
        public string CourseName { get; set; }
    }

    public class CourseResponse : CourseRequest
    {
        public Guid Id { get; set; }
    }

    public class UpdateCourseRequest
    {
        public Guid Id { get; set; }

        public string CourseName { get; set; }
    }
}
