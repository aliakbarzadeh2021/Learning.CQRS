using System;
using Learning.CQRS.CommandBus.Messages;
using Learning.CQRS.Messages.Command.LearningCenterModule.Validators.ElectronicSource;
using Learning.CQRS.Messages.Command.Seedworks;

namespace Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicSource
{
   public class CreateEducationalGameCommand : CommandBase
    {

        /// <summary>
        /// OwnerId
        /// </summary>
        public Guid OwnerId { get; set; }

        /// <summary>
        ///  نام پیشنهاددهنده
        /// </summary>
        public string ProposerName { get; set; }

   

        /// <summary>
        /// بررسی پروپرتی ها
        /// </summary>
        public override void Validate()
        {
            new CreateEducationalGameCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}
