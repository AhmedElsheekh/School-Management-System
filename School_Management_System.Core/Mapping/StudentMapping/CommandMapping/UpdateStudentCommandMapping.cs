using School_Management_System.Core.Features.Students.Commands.Models;
using School_Management_System.Domain.Entities;

namespace School_Management_System.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void UpdateStudentCommandMapping()
        {
            CreateMap<UpdateStudentCommand, Student>();
        }
    }
}
