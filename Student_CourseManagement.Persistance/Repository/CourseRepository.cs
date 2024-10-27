using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Persistance.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Persistance.Repository
{
    public class CourseRepository : BaseRepository, ICourseRepository
    {
        private readonly AppDbContext dbContext;
        private string query;
        public CourseRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<int>> RemoveStudentsInCourse(Guid courseId)
        {
            query = @" UPDATE Students SET IsAssigned = 0 WHERE Id IN (
                SELECT StudentId FROM StudentCourses WHERE CourseId = @CourseId)";
            return await QueryAsync<int>(query, new {CourseId=courseId});
        }
    }
}
