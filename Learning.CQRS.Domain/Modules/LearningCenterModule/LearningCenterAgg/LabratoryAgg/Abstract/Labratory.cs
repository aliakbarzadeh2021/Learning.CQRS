using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg.Abstract
{

    /// <summary>
    /// مرکز یادگیری
    /// </summary>
    public abstract class Labratory : LearningCenterAgg.Abstract.LearningCenter, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Labratory"/> class.
        /// </summary>
        public Labratory(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string manufacturerLabratory, string instructionsLabratory, string subjecttLab) 
                          : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc)
        {
            SubjectLab = subjecttLab;
            ManufacturerLabratory = manufacturerLabratory;
            InstructionsLabratory = instructionsLabratory;
        }





        /// <summary>
        /// موضوع
        /// </summary>
        public string SubjectLab { get; set; }

        /// <summary>
        /// فایل اصلی
        /// </summary>
        public string ManufacturerLabratory { get; private set; }


        /// <summary>
        /// فایل اصلی
        /// </summary>
        public string InstructionsLabratory { get; private set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected Labratory()
        {
        }

        public override void Validate()
        {

        }
    }
}
