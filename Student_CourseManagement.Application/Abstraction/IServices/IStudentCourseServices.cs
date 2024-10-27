using Student_CourseManagement.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IServices
{
    public interface IStudentCourseServices
    {
        Task<int> AddStudentCourse(Guid studentId,Guid courseId);

        Task<StudentCourseRequest> GetAllCourses();

        Task<IEnumerable<StudentCourseResponse>> GetStudentCourses(Guid courseId);


        Task<IEnumerable<StudentCourseResponse>> GetAllStudentsInCourses();

        Task<int> DeleteStudentFromCourse(Guid id);
    }
}
