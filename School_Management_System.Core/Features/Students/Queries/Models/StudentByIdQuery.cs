using MediatR;
using School_Management_System.Core.Bases;
using School_Management_System.Core.Features.Students.Queries.DTOs;
using School_Management_System.Core.Responses;
using School_Management_System.Service.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Features.Students.Queries.Models
{
    public class StudentByIdQuery : IRequest<BaseResponse>
    {
        public StudentByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
