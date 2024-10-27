using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Application.Abstraction.IServices;
using Student_CourseManagement.Application.RRModels;
using Student_CourseManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.services
{
    partial class StudentCourseServices : IStudentCourseServices
    {
        private readonly IStudentCourseRepository repository;
        private readonly IMapper mapper;

        public StudentCourseServices(IStudentCourseRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<int> AddStudentCourse(Guid studentId, Guid courseId)
        {
            bool isExists = await repository.IsExists<StudentCourse>(x=>x.StudentId==studentId);
            if (!isExists &&studentId != Guid.Empty && courseId != Guid.Empty)
            {
                var student = await repository.GetById<Student>(studentId);
                student.IsAssigned = true;
                StudentCourse studentCourse = new StudentCourse()
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    
                };

                if (await repository.AddAsync<StudentCourse>(studentCourse) > 0 &&
                    await repository.UpdateAsync<Student>(student) > 0)
                {
                    return 1;
                }
            }
            return 0;
        }

        public async Task<int> DeleteStudentFromCourse(Guid id)
        {
            var studentCourse = await repository.GetById<StudentCourse>(id);

            if (studentCourse is not null)
            {
                var student = await repository.GetById<Student>(studentCourse.StudentId);
                student.IsAssigned = false;

                if (await repository.DeleteAsync<StudentCourse>(studentCourse) > 0 && 
                    await repository.UpdateAsync<Student>(student) > 0)
                {
                    return 1;
                }
            }
           return 0;
        }

        public async Task<StudentCourseRequest> GetAllCourses()
        {
            var courses = await repository.GetAllAsync<Course>();
            var students = await repository.FindBy<Student>(x=>x.IsAssigned==false);
            if (courses is not null && students is not null)
            {
                StudentCourseRequest studentCourse= new StudentCourseRequest();
                studentCourse.courses = courses.Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.CourseName,
                }).ToList();
                studentCourse.students = mapper.Map<List<StudentResponse>>(students);

                return studentCourse;
            }
            return null;
        }

        public async Task<IEnumerable<StudentCourseResponse>> GetAllStudentsInCourses()
        {
            var studentCourses = await repository.GetAllStudentsinCourses();
            if (studentCourses is not null)
            {
                return studentCourses;
            }
            return Enumerable.Empty<StudentCourseResponse>();
        }

        public async Task<IEnumerable<StudentCourseResponse>> GetStudentCourses(Guid courseId)
        {
            var students = await repository.GetStudentsByCourseId(courseId);

            if (students is not null)
            {
                return students;
            }
            return Enumerable.Empty<StudentCourseResponse>();
        }
    }
}
