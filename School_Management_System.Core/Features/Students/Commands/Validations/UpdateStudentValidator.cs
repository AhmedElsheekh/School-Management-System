using FluentValidation;
using School_Management_System.Core.Features.Students.Commands.Models;
using School_Management_System.Service.Interfaces;

namespace School_Management_System.Core.Features.Students.Commands.Validations
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentService _studentService;

        public UpdateStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(s => s.Name)
               .NotEmpty()
               .WithMessage("Name should not be empty")
               .MaximumLength(20)
               .WithMessage("Name maximum length is 20 letters");

            RuleFor(s => s.Address)
                .NotEmpty()
                .WithMessage("Address should not be empty")
                .MaximumLength(100)
                .WithMessage("Address maximum length is 100 letters");
        }

        public void ApplyCustomValidationRules()
        {
            RuleFor(s => s.Name)
                .MustAsync(async (model, name, CancellationToken) =>
                !await _studentService.IsNameExistsExcludeSelf(name, model.Id))
                .WithMessage("The name is already exists");
        }
    }
}
