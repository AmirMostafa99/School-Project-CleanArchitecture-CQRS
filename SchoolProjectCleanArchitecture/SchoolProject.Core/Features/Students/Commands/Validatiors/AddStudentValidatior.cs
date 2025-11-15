using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Core.Resources;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class AddStudentValidatior : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentservice;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IDepartmentService _departmentService;

        #endregion

        #region Constructor
        public AddStudentValidatior(IStudentService studentservice,
                                    IStringLocalizer<SharedResources> localizer,
                                    IDepartmentService departmentService)
        {
            _studentservice = studentservice;
            _localizer = localizer;

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _departmentService = departmentService;

        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.Address)
              .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
              .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required])
              .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLengthis100]);

            RuleFor(x => x.DepartmentId)
                 .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                 .NotNull().WithMessage(_localizer[SharedResourcesKeys.Required]);
        }

        public void ApplyCustomValidationsRules()
        {
            // Add any custom validation rules here if needed in the future
            RuleFor(x => x.NameAr)
                .MustAsync(async (key, cancellation) => !await _studentservice.IsNameExist(key))
                .WithMessage(_localizer[SharedResourcesKeys.IsExist]);
            RuleFor(x => x.NameEn)
               .MustAsync(async (Key, CancellationToken) => !await _studentservice.IsNameExist(Key))
               .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.DepartmentId)
                .MustAsync(async (Key, CancellationToken) => Key.HasValue && await _departmentService.IsDepartmentIdExist(Key.Value))
                .WithMessage(_localizer[SharedResourcesKeys.IsNotExist]);
        }
        #endregion
    }
}



