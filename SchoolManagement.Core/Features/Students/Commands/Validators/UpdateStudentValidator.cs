using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolManagement.Core.Features.Students.Commands.Models;
using SchoolManagement.Core.Resources;
using SchoolManagement.Service.Interfaces;

namespace SchoolManagement.Core.Features.Students.Commands.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudentCommand>
    {
        private readonly IStudentService _studentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        public UpdateStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
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
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsPhoneExistsExcludeSelf(model.StudentId, Key))
                .WithMessage(_stringLocalizer[SharedResourcesKeys.PhoneExists]);
        }
    }
}
