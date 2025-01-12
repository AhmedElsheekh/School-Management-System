using FluentValidation;
using School_Management_System.Core.Features.Students.Commands.Models;
using School_Management_System.Service.Interfaces;

namespace School_Management_System.Core.Features.Students.Commands.Validations
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;

        public AddStudentValidator(IStudentService studentService)
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
            _studentService = studentService;
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
                .MustAsync(async (key, CancellationToken) =>
                !await _studentService.IsNameExists(key))
                .WithMessage("The name is already exists");
        }
    }
}
