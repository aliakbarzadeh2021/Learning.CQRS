using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
    public class Thesis : ElectronicDocument, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Thesis"/> class.
        /// </summary>
        public Thesis(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear,
                      string originalFile, FileType fileType, string providerOrganizationThesis, string authersNameThesis)
            : base(
               id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, publishingYear, originalFile, fileType)
        {
            ProviderOrganizationThesis = providerOrganizationThesis;
            AuthersNameThesis = authersNameThesis;

        }

        /// <summary>
        ///  سازمان ارائه دهنده 
        /// </summary>
        public string ProviderOrganizationThesis { get; set; }

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        public string AuthersNameThesis { get; set; }



        /// <summary>
        /// For EF!
        /// </summary>
        protected Thesis()
        {
        }

        public override void Validate()
        {

        }
    }
}
