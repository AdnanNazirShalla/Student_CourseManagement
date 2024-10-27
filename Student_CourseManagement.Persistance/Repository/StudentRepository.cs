using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Persistance.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Persistance.Repository
{
    internal class StudentRepository : BaseRepository,IStudentRepository
    {
        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
