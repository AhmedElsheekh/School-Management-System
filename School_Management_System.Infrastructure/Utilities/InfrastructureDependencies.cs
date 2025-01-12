using Microsoft.Extensions.DependencyInjection;
using School_Management_System.Infrastructure.Bases;
using School_Management_System.Infrastructure.Interfaces;
using School_Management_System.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Infrastructure.Utilities
{
    public static class InfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentRepository, StudentRepository>();
            
            return services;
        }
    }
}
