using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.RRModels
{
    public class StudentRequest
    {
        [Required(ErrorMessage ="Name is Required!")]
        public string Name { get; set; } =string.Empty;


        [Required(ErrorMessage = "Email is Required!")]
        public string Email { get; set; } = string.Empty;

        //[Required(ErrorMessage ="Select Not Selected!")]
        //public Guid CourseId { get; set; }


        [Required(ErrorMessage = "Age is Required!")]
        public int Age { get; set; }


        [Required(ErrorMessage = "ContactNo is Required!")]
        public string ContactNo { get; set; } = string.Empty;
    }

    public class StudentResponse : StudentRequest
    {
        public Guid Id { get; set; }
    }


    public class StudentUpdateRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;


        public string Email { get; set; } = string.Empty;

        public Guid CourseId { get; set; }


        public int Age { get; set; }


        public string ContactNo { get; set; } = string.Empty;
    }
}
