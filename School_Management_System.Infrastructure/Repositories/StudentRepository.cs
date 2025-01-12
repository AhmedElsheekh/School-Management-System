using Microsoft.EntityFrameworkCore;
using School_Management_System.Domain.Entities;
using School_Management_System.Infrastructure.Bases;
using School_Management_System.Infrastructure.Data;
using School_Management_System.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Infrastructure.Repositories
{
    public class StudentRepository : GenericRepository<Student, int>, IStudentRepository
    {
        #region Fields
        private readonly ApplicationDBContext _dBContext;
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDBContext dBContext) : base(dBContext)
        {
            _dBContext = dBContext;
            _students = _dBContext.Set<Student>();
        }
        #endregion

        #region Methods
        public async Task<List<Student>> GetAsync()
        {
            return await _students.Include(st => st.Department).ToListAsync();
        }
        #endregion

    }
}
