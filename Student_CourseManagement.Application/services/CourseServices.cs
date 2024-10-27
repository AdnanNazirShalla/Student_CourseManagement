using AutoMapper;
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
    public class CourseServices : ICourseServices
    {
        private readonly ICourseRepository repository;
        private readonly IMapper mapper;

        public CourseServices(ICourseRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<int> AddCourse(CourseRequest model)
        {
            var isExists = await repository.IsExists<Course>(x=>x.CourseName== model.CourseName);

            if (!isExists)
            {
                var course=mapper.Map<Course>(model);
                course.Id = Guid.NewGuid();

                if (await repository.AddAsync<Course>(course) > 0)
                {
                    return 1;
                }
                return 0;
            }
            return -1;
        }

        public async Task<int> DeleteCourse(Guid id)
        {
            var studentsInCourse = await repository.FindBy<StudentCourse>(x=>x.CourseId==id);
            var updateStudents= await repository.RemoveStudentsInCourse(id);
            var course = await repository.GetById<Course>(id);

            if (await repository.DeleteAsync<Course>(course) > 0)
            {
                if (studentsInCourse != null)
                {
                    await repository.DeleteRangeAsync<StudentCourse>(studentsInCourse);
                }
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<CourseResponse>> GetAllCouurses()
        {
            var courses = await repository.GetAllAsync<Course>();
            if (courses is not null)
            {
                return mapper.Map<IEnumerable<CourseResponse>>(courses);
            }
            return Enumerable.Empty<CourseResponse>();
        }

        public async Task<CourseResponse> GetCourseById(Guid id)
        {
            var course = await repository.GetById<Course>(id);
            if (course is not null)
            {
                return mapper.Map<CourseResponse>(course);
            }
            return null;
        }

        public async Task<int> UpdateCourse(UpdateCourseRequest model)
        {
            var course = await repository.GetById<Course>(model.Id);
            if (course is not null)
            {
                course.CourseName= model.CourseName;

                if (await repository.UpdateAsync<Course>(course) > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
