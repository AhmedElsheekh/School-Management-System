using School_Management_System.Core.Features.Students.Queries.DTOs;
using School_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Mapping.StudentMapping
{
    public partial class StudentProfile
    {
        public void GetStudentMapping()
        {
            CreateMap<Student, StudentDetailsResult>()
                .ForMember(des => des.Department, x => x.MapFrom(src => src.Department.Name));
        }
    }
}
