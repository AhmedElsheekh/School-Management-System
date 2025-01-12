using School_Management_System.Domain.Entities;
using School_Management_System.Infrastructure.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Infrastructure.Interfaces
{
    public interface IStudentRepository : IGenericRepository<Student, int>
    {
        Task<List<Student>> GetAsync();
    }
}
