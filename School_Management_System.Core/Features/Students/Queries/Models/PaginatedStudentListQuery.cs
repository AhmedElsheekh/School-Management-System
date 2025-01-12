using MediatR;
using School_Management_System.Core.Features.Students.Queries.Results;
using School_Management_System.Core.Wrappers;

namespace School_Management_System.Core.Features.Students.Queries.Models
{
    public class PaginatedStudentListQuery : IRequest<PaginatedResult<PaginatedStudentsListResult>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? Search { get; set; }
        public string[]? OrderBy { get; set; }
    }
}
