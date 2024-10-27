using Student_CourseManagement.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IRepository
{
    public interface IStudentCourseRepository : IBaseRepository
    {
        Task<IEnumerable<StudentCourseResponse>> GetStudentsByCourseId(Guid courseId);

        Task<IEnumerable<StudentCourseResponse>> GetAllStudentsinCourses();
    }
}
