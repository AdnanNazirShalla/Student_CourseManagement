using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Domain.Models
{
    public class Course
    {
        public Guid Id { get; set; }

        public string CourseName { get; set; }
    }
}
