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
    public class StudentServices : IStudentServices
    {
        private readonly IStudentRepository repository;
        private readonly IMapper mapper;

        public StudentServices(IStudentRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<int> AddStudent(StudentRequest model)
        {
            bool isExists = await repository.IsExists<Student>(x => x.Email == model.Email);
            if (!isExists)
            {
                Student student = mapper.Map<Student>(model);
                student.Id= Guid.NewGuid();
                student.IsAssigned = false;

                if (await repository.AddAsync<Student>(student) > 0)
                {
                    return 1;
                }
                return 0;
            }
            else
            {
                return -1;
            }
        }

        public async Task<int> DeleteStudent(Guid id)
        {
            var student = await repository.GetById<Student>(id);
            if (await repository.DeleteAsync<Student>(student) > 0)
            {
                return 1;
            }
            return 0;
        }

        public async Task<IEnumerable<StudentResponse>> GetAllStudents()
        {
            var students = await repository.GetAllAsync<Student>();

            if (students != null)
            {
                return mapper.Map<IEnumerable<StudentResponse>>(students);
            }
            return Enumerable.Empty<StudentResponse>();
        }

        public async Task<StudentResponse> GetStudentById(Guid id)
        {
            var student = await repository.GetById<Student>(id);
            if (student is not null)
            {
                return mapper.Map<StudentResponse>(student);
            }
            return null;
        }

        public async Task<int> UpdateStudent(StudentUpdateRequest model)
        {
            var student = await repository.FirstOrDefault<Student>(x=>x.Id == model.Id);
            if (student is not null)
            {
                student.Name=model.Name;
                student.Email=model.Email;
                student.Age=model.Age;

                if (await repository.UpdateAsync<Student>(student) > 0)
                {
                    return 1;
                }
            }
            return 0;
        }
    }
}
