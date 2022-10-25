using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
    public class Article : ElectronicDocument, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Article"/> class.
        /// </summary>
        public Article(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear,
                       string originalFile, FileType fileType, string providerOrganizationArticle, string authersNameArticle, string originalAbstractfile)
            : base(
                id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, publishingYear, originalFile, fileType)
        {
            ProviderOrganizationArticle = providerOrganizationArticle;
            AuthersNameArticle = authersNameArticle;
            OriginalAbstractfile = originalAbstractfile;

        }

        /// <summary>
        ///  سازمان ارائه دهنده 
        /// </summary>
        public string ProviderOrganizationArticle { get; set; }

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        public string AuthersNameArticle { get; set; }


        /// <summary>
        ///  فایل چکیده 
        /// </summary>
        public string OriginalAbstractfile { get; set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected Article()
        {
        }

        public override void Validate()
        {

        }
    }
}
