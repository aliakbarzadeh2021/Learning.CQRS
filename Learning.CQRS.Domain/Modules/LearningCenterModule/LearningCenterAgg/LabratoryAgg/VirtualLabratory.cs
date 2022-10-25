using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg.Abstract;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg
{
    public class VirtualLabratory : Labratory, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VirtualLabratory"/> class.
        /// </summary>
        public VirtualLabratory(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string subjecttLab, string manufacturer, string instructions, string lable, int productionYearVirtualLab)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, subjecttLab, manufacturer, instructions)
        {
            Lable = lable;
            ProductionYearVirtualLab = productionYearVirtualLab;
        }

        /// <summary>
        /// برچسب
        /// </summary>
        public string Lable { get; set; }


        /// <summary>
        /// سال تولید
        /// </summary>
        public int ProductionYearVirtualLab { get; set; }


        /// <summary>
        /// For EF!
        /// </summary>
        protected VirtualLabratory()
        {
        }

        public override void Validate()
        {

        }
    }
}
