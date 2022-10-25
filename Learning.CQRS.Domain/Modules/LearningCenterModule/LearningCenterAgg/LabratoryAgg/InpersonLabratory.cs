using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg.Abstract;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg
{
    public class InpersonLabratory : Labratory, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InpersonLabratory"/> class.
        /// </summary>
        public InpersonLabratory(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string subjecttLab,
                        string manufacturer, string instructions, string softwareNeededToOpenFileInpersonLab)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, subjecttLab,  manufacturer, instructions)
        {
            SoftwareNeededToOpenFileInpersonLab = softwareNeededToOpenFileInpersonLab;
        }

        /// <summary>
        /// نرم افزار موردنیاز برای باز کردن فایل
        /// </summary>
        public string SoftwareNeededToOpenFileInpersonLab { get; set; }


        /// <summary>
        /// For EF!
        /// </summary>
        protected InpersonLabratory()
        {
        }

        public override void Validate()
        {

        }
    }
}
