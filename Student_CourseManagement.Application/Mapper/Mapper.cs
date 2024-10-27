using AutoMapper;
using Student_CourseManagement.Application.RRModels;
using Student_CourseManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Mapper
{
    public sealed class StudentProfile:Profile
    {
        public StudentProfile()
        {
            CreateMap<StudentRequest, Student>();
            CreateMap<StudentUpdateRequest, Student>();
            CreateMap<Student, StudentResponse>();
        }
    }

    public sealed class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<CourseRequest, Course>();
            CreateMap<Course, CourseResponse>();
        }
    }

}
