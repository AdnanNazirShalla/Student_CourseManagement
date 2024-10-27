using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IRepository
{
    public interface ICourseRepository : IBaseRepository
    {
        Task<IEnumerable<int>> RemoveStudentsInCourse(Guid courseId);
    }
}
