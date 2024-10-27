using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Persistance.DB;
using Student_CourseManagement.Persistance.Repository;

namespace Student_CourseManagement.Persistance
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContextPool<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(nameof(AppDbContext)));
            });

            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IStudentCourseRepository, StudentCourseRepository>();
            return services;
        }

    }
}
