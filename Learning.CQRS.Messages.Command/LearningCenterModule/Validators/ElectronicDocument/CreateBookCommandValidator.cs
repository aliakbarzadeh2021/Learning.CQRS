
namespace Learning.CQRS.Messages.Command.LearningCenterModule.Validators.ElectronicDocument
{

    using FluentValidation;
    using Messages.ElectronicDocument;

    /// <summary>
    /// اعتبار سنجی پروپرتی ها
    /// </summary>
    class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateBookCommandValidator"/> class.
        /// </summary>
        internal CreateBookCommandValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.ProposerName).NotNull().NotEmpty().WithMessage("نام پیشنهاددهنده محتوا  خالی است ");
            RuleFor(p => p.Title).NotNull().NotEmpty().WithMessage("عنوان خالی است ");
            RuleFor(p => p.PublisherName).NotNull().NotEmpty().WithMessage("ناشر خالی است ");
            RuleFor(p => p.AuthersName).NotNull().NotEmpty().WithMessage("نویسندگان خالی است ");

            RuleFor(p => p.Privileges).NotNull().NotEmpty().WithMessage("نوع دسترسی خالی است ");
            RuleFor(p => p.LeasonGradeList).NotNull().NotEmpty().WithMessage("لیست پایه و درس خالی است ");

        }
    }
}
