using Student_CourseManagement.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IServices
{
    public interface IStudentServices
    {
        Task<int> AddStudent(StudentRequest model);

        Task<IEnumerable<StudentResponse>> GetAllStudents();

        Task<int> UpdateStudent(StudentUpdateRequest model);

        Task<StudentResponse> GetStudentById(Guid id);

        Task<int> DeleteStudent(Guid id);
    }
}
