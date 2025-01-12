using AutoMapper;
using MediatR;
using School_Management_System.Core.Bases;
using School_Management_System.Core.Features.Students.Queries.DTOs;
using School_Management_System.Core.Features.Students.Queries.Models;
using School_Management_System.Core.Features.Students.Queries.Results;
using School_Management_System.Core.Responses;
using School_Management_System.Core.Wrappers;
using School_Management_System.Service.Interfaces;

namespace School_Management_System.Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<StudentsListQuery, BaseResponse>,
        IRequestHandler<StudentByIdQuery, BaseResponse>,
        IRequestHandler<PaginatedStudentListQuery, PaginatedResult<PaginatedStudentsListResult>>
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentQueryHandler(IStudentService studentService,
            IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public async Task<BaseResponse> Handle(StudentsListQuery request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _studentService.GetAllAsync();
            var mappedStudents = _mapper.Map<List<StudentDetailsResult>>(serviceResponse.Data);
            return new SuccessResponse<List<StudentDetailsResult>>(mappedStudents);
        }

        public async Task<BaseResponse> Handle(StudentByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceResponse = await _studentService.GetByIdWithIncludeAsync(request.Id);
            if (!serviceResponse.IsSuccess)
                return new NotFoundResponse(serviceResponse.Message);

            var mappedStudent = _mapper.Map<StudentDetailsResult>(serviceResponse.Data);
            return new SuccessResponse<StudentDetailsResult>(mappedStudent, serviceResponse.Message);
        }

        public Task<PaginatedResult<PaginatedStudentsListResult>> Handle(PaginatedStudentListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
