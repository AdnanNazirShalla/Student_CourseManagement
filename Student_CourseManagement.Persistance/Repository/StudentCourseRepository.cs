using Microsoft.EntityFrameworkCore;
using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Application.RRModels;
using Student_CourseManagement.Domain.Models;
using Student_CourseManagement.Persistance.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Persistance.Repository
{
    public class StudentCourseRepository : BaseRepository,IStudentCourseRepository
    {
        private readonly AppDbContext dbContext;
        private  string query;
        public StudentCourseRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<StudentCourseResponse>> GetAllStudentsinCourses()
        {
            query = $@"SELECT sc.Id, s.Id AS StudentId, s.[Name] AS StudentName, c.Id AS CourseId, c.CourseName                  
                    FROM StudentCourses sc JOIN Students s ON sc.StudentId = s.Id JOIN 
                    Courses c ON sc.CourseId = c.Id order by c.CourseName asc";

            return await QueryAsync<StudentCourseResponse>(query);
        }

        public async Task<IEnumerable<StudentCourseResponse>> GetStudentsByCourseId(Guid courseId)
        {
            query= $@"SELECT sc.Id, s.Id AS StudentId, s.[Name] AS StudentName, c.Id AS CourseId, c.CourseName 
                    FROM StudentCourses sc JOIN Students s ON sc.StudentId = s.Id JOIN Courses c 
                    ON sc.CourseId = c.Id WHERE c.Id =@CourseId";

            var res= await QueryAsync<StudentCourseResponse>(query, new {CourseId=courseId});
            return res;
            //return (Task<IEnumerable<StudentCourseResponse>>)dbContext.StudentCourses.FromSqlRaw(query);
        }

        
    }
}
