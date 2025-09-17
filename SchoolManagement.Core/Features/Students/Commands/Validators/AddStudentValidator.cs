using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Students.Commands.Validators
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidation();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.FirstNameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(string.Format(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength], 3, 100))
                .MinimumLength(3).WithMessage(string.Format(_stringLocalizer[SharedResourcesKeys.LessThanMinLength], 3, 100));

            RuleFor(x => x.LastNameEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage($"{_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]}")
                .MinimumLength(3).WithMessage($"{_stringLocalizer[SharedResourcesKeys.LessThanMinLength]}");

            RuleFor(x => x.AddressEn)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(300).WithMessage($"{_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]}")
                .MinimumLength(4).WithMessage($"{_stringLocalizer[SharedResourcesKeys.LessThanMinLength]}");

            RuleFor(x => x.FirstNameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(string.Format(_stringLocalizer[SharedResourcesKeys.ExceededMaxLength], 3, 100))
                .MinimumLength(3).WithMessage(string.Format(_stringLocalizer[SharedResourcesKeys.LessThanMinLength], 3, 100));

            RuleFor(x => x.LastNameAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage($"{_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]}")
                .MinimumLength(3).WithMessage($"{_stringLocalizer[SharedResourcesKeys.LessThanMinLength]}");

            RuleFor(x => x.AddressAr)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(300).WithMessage($"{_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]}")
                .MinimumLength(4).WithMessage($"{_stringLocalizer[SharedResourcesKeys.LessThanMinLength]}");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.NotNull])
                .MaximumLength(13).WithMessage($"{_stringLocalizer[SharedResourcesKeys.ExceededMaxLength]}")
                .MinimumLength(11).WithMessage($"{_stringLocalizer[SharedResourcesKeys.LessThanMinLength]}");
        }

        public void ApplyCustomValidation()
        {
            RuleFor(x => x.Phone)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsPhoneExists(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.PhoneExists]);

            RuleFor(x => x.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExists(Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.NotFound]);
        }
    }
}
