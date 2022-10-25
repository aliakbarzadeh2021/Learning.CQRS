using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg.Abstract
{
    using LearningCenterAgg.Abstract;
    public abstract class ElectronicSource : LearningCenter, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicSource"/> class.
        /// </summary>
        protected ElectronicSource(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string subjectSource) 
                          : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc)
        {
            SubjectSource = subjectSource;
        }


        /// <summary>
        /// موضوع
        /// </summary>
        public string SubjectSource { get; set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected ElectronicSource()
        {
        }

        public override void Validate()
        {

        }
    }
}
