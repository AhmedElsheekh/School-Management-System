using AutoMapper;

namespace School_Management_System.Core.Mapping.StudentMapping
{
    public partial class StudentProfile : Profile
    {
        public StudentProfile()
        {
            GetStudentMapping();
            AddStudentCommandMapping();
            UpdateStudentCommandMapping();
        }
    }
}
