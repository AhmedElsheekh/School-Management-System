using Microsoft.EntityFrameworkCore;
using School_Management_System.Domain.Entities;
using School_Management_System.Infrastructure.Interfaces;
using School_Management_System.Service.Interfaces;
using School_Management_System.Service.Responses;

namespace School_Management_System.Service.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<ServiceResponse<Student>> AddAsync(Student student)
        {

            await _studentRepository.AddAsync(student);
            await _studentRepository.SaveChangesAsync();

            return new ServiceResponse<Student>(true, ServiceResponseMessages.CreatedSuccessfully);
        }

        public async Task<ServiceResponse<Student>> DeleteAsync(int id)
        {
            var response = await GetByIdAsync(id);
            if (!response.IsSuccess)
                return response;

            _studentRepository.Delete(response.Data);
            await _studentRepository.SaveChangesAsync();
            return new ServiceResponse<Student>(true, ServiceResponseMessages.DeletedSuccessfully);
        }

        public async Task<ServiceResponse<List<Student>>> GetAllAsync()
        {
            var students = await _studentRepository.GetAsync();
            return new ServiceResponse<List<Student>>(true, "Successful response", students);
        }

        public async Task<ServiceResponse<Student>> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student is null)
                return new ServiceResponse<Student>(false, ServiceResponseMessages.EntityNotFound);

            return new ServiceResponse<Student>(true, "Successful response", student);
        }

        public async Task<ServiceResponse<Student>> GetByIdWithIncludeAsync(int id)
        {
            var student = await _studentRepository.GetNoTracking()
                .Include(s => s.Department)
                .Where(s => s.Id == id)
                .FirstOrDefaultAsync();

            if (student is null)
                return new ServiceResponse<Student>(false, $"Student with Id = {id} is not found");

            return new ServiceResponse<Student>(true, "Successfull response", student);
        }

        public async Task<bool> IsNameExists(string name)
        {
            var student = await _studentRepository.GetNoTracking()
                .Where(s => s.Name.ToLower() == name.ToLower()).FirstOrDefaultAsync();
            return student is not null;
        }

        public async Task<bool> IsNameExistsExcludeSelf(string name, int id)
        {
            var student = await _studentRepository.GetNoTracking()
                .Where(s => s.Name.ToLower() == name.ToLower() && s.Id != id).FirstOrDefaultAsync();
            return student is not null;
        }

        public async Task<ServiceResponse<Student>> UpdateAsync(Student student)
        {
            _studentRepository.Update(student);
            await _studentRepository.SaveChangesAsync();

            return new ServiceResponse<Student>(true, ServiceResponseMessages.UpdatedSuccessfully);
        }
    }
}
