
namespace Learning.CQRS.Messages.Command.LearningCenterModule.Validators.ElectronicSource
{

    using FluentValidation;
    using Messages.ElectronicSource;

    /// <summary>
    /// اعتبار سنجی پروپرتی ها
    /// </summary>
    class CreateEducationalGameCommandValidator : AbstractValidator<CreateEducationalGameCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEducationalGameCommandValidator"/> class.
        /// </summary>
        internal CreateEducationalGameCommandValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(p => p.ProposerName).NotNull().NotEmpty().WithMessage("نام پیشنهاددهنده محتوا  خالی است ");
         

        }
    }
}
