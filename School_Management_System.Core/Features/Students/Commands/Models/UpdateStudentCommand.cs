using MediatR;
using School_Management_System.Core.Responses;

namespace School_Management_System.Core.Features.Students.Commands.Models
{
    public class UpdateStudentCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
