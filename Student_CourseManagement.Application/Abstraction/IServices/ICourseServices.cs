using Student_CourseManagement.Application.RRModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IServices
{
    public interface ICourseServices
    {
        Task<int> AddCourse(CourseRequest model);

        Task<IEnumerable<CourseResponse>> GetAllCouurses();

        Task<int> UpdateCourse(UpdateCourseRequest model);

        Task<CourseResponse> GetCourseById(Guid id);

        Task<int> DeleteCourse(Guid id);
    }
}
