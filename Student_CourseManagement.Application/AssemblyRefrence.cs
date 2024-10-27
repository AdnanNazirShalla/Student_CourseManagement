using Microsoft.Extensions.DependencyInjection;
using Student_CourseManagement.Application.Abstraction.IServices;
using Student_CourseManagement.Application.services;
using System.Reflection;

namespace Student_CourseManagement.Application
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IStudentServices, StudentServices>();
            services.AddScoped<ICourseServices, CourseServices>();
            services.AddScoped<IStudentCourseServices, StudentCourseServices>();
            return services;
        }
    }
}
