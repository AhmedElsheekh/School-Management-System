using MediatR;
using School_Management_System.Core.Responses;

namespace School_Management_System.Core.Features.Students.Commands.Models
{
    public class DeleteStudentCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }

        public DeleteStudentCommand(int id)
        {
            Id = id;
        }
    }
}
