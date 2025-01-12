using MediatR;
using School_Management_System.Core.Bases;
using School_Management_System.Core.Features.Students.Queries.DTOs;
using School_Management_System.Core.Responses;
using School_Management_System.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School_Management_System.Core.Features.Students.Queries.Models
{
    public class StudentsListQuery : IRequest<BaseResponse>
    {
    }
}
