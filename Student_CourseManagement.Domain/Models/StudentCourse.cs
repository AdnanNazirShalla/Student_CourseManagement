using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Domain.Models
{
    public class StudentCourse
    {
        public Guid Id { get; set; }

        public Guid StudentId { get; set; }


        public Guid CourseId { get; set; }



        [ForeignKey(nameof(StudentId))]
        public List<Student> student { get; set; }


        [ForeignKey(nameof(CourseId))]
        public List<Course> course { get; set; }
    }
}
