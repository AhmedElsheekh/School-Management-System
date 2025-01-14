using School_Management_System.Domain.Entities;
using School_Management_System.Domain.Helpers;
using School_Management_System.Service.Responses;

namespace School_Management_System.Service.Interfaces
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<Student>>> GetAllAsync();
        Task<ServiceResponse<Student>> GetByIdWithIncludeAsync(int id);
        Task<ServiceResponse<Student>> GetByIdAsync(int id);
        Task<ServiceResponse<Student>> AddAsync(Student student);
        Task<ServiceResponse<Student>> UpdateAsync(Student student);
        Task<ServiceResponse<Student>> DeleteAsync(int id);
        Task<bool> IsNameExists(string name);
        Task<bool> IsNameExistsExcludeSelf(string name, int id);
        IQueryable<Student> GetStudentQueryable(string search, StudentOrderingEnum orderBy);
    }
}
