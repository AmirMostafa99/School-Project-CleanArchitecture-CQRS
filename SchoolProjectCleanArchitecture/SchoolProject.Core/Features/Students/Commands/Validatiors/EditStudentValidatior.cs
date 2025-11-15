using FluentValidation;
using SchoolProject.Core.Features.Students.Commands.Models;
using SchoolProject.Service.Abstracts;

namespace SchoolProject.Core.Features.Students.Commands.Validatiors
{
    public class EditStudentValidatior : AbstractValidator<EditStudentCommand>
    {

        #region Fields
        private readonly IStudentService _studentservice;
        #endregion

        #region Constructor
        public EditStudentValidatior(IStudentService _studentservice)
        {
            this._studentservice = _studentservice ?? throw new ArgumentNullException(nameof(_studentservice));
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage("Student name is required.")
                .NotNull().WithMessage("Student name must not be null.")
                .MaximumLength(100).WithMessage("Student name must not exceed 100 characters.");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage(" {propertyValue} must not be null.")
                .MaximumLength(100).WithMessage("{PropertyName} must not exceed 100 characters.");
        }

        public void ApplyCustomValidationsRules()
        {
            // Add any custom validation rules here if needed in the future
            RuleFor(x => x.NameAr)
                .MustAsync(async (model, key, cancellation) => !await _studentservice.IsNameExistExcludeSelf(key, model.Id))
                .WithMessage("Student name already exists.");


        }
        #endregion
    }
}

