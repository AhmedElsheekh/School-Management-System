using AutoMapper;
using MediatR;
using School_Management_System.Core.Bases;
using School_Management_System.Core.Features.Students.Commands.Models;
using School_Management_System.Core.Responses;
using School_Management_System.Domain.Entities;
using School_Management_System.Service.Interfaces;

namespace School_Management_System.Core.Features.Students.Commands.Handlers
{
    public class StudentCommandHandler : ResponseHandler,
        IRequestHandler<AddStudentCommand, BaseResponse>,
        IRequestHandler<UpdateStudentCommand, BaseResponse>,
        IRequestHandler<DeleteStudentCommand, BaseResponse>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentCommandHandler(IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Student>(request);
            var serviceResponse = await _studentService.AddAsync(student);

            if (!serviceResponse.IsSuccess)
                return new BadRequestResponse(serviceResponse.Message);

            return new CreatedResponse();
        }

        public async Task<BaseResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = await _studentService.GetByIdAsync(request.Id);
            if (!response.IsSuccess)
                return new NotFoundResponse("Student is not found");

            var mappedStudent = _mapper.Map<Student>(request);

            var result = await _studentService.UpdateAsync(mappedStudent);

            if (!result.IsSuccess)
                return new BadRequestResponse();

            return new NoContentResponse("Updated successfully");
        }

        public async Task<BaseResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _studentService.DeleteAsync(request.Id);
            if (!serviceResponse.IsSuccess)
                return new NotFoundResponse(serviceResponse.Message);
            return new NoContentResponse(serviceResponse.Message);
        }
    }
}
