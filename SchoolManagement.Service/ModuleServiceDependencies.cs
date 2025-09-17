using Microsoft.Extensions.DependencyInjection;
using SchoolManagement.Service.Implementation;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<IDepartmentService, DepartmentService>();

            return services;
        }
    }
}
