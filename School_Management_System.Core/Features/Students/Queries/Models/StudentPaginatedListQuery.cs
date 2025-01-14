using MediatR;
using School_Management_System.Core.Features.Students.Queries.Results;
using School_Management_System.Core.Wrappers;
using School_Management_System.Domain.Helpers;

namespace School_Management_System.Core.Features.Students.Queries.Models
{
    public class StudentPaginatedListQuery : IRequest<PaginatedResult<StudentPaginatedListResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
    }
}
