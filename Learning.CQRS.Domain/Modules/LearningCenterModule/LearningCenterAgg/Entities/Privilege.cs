using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities
{
   public class Privilege: EntityBase<Guid>
    {
        public Privilege( Guid id , AccessType accessType)
        {
            Id = id;
            AccessType = accessType;
        }

        /// <summary>
        ///  نوع دسترسی
        /// </summary>
        public AccessType AccessType { get; set; }


        public override void Validate()
        {

        }
    }
}
