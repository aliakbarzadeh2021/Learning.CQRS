using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg
{
    public class InformationBase : ElectronicSource, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InformationBase"/> class.
        /// </summary>
        public InformationBase(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string subjectSource, string concessionaireInformationBase, string urlInformationBase)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, subjectSource)
        {
            ConcessionaireInformationBase = concessionaireInformationBase;
            UrlInformationBase = urlInformationBase;
        }

        /// <summary>
        /// صاحب امتیاز سایت 
        /// </summary>
        public string ConcessionaireInformationBase { get; set; }

        /// <summary>
        ///  url 
        /// </summary>
        public string UrlInformationBase { get; set; }



        /// <summary>
        /// For EF!
        /// </summary>
        protected InformationBase()
        {
        }

        public override void Validate()
        {

        }
    }
}
