using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
  public  class Book : ElectronicDocument, IAggregateRoot
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        public Book(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear, string originalFile, FileType fileType, string publisherName, string authersName, string translatorsName, string softwareNeededToOpenFile) 
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, publishingYear, originalFile, fileType)
        {
            PublisherName = publisherName;
            AuthersName = authersName;
            TranslatorsName = translatorsName;
            SoftwareNeededToOpenFile = softwareNeededToOpenFile;
        }

        /// <summary>
        ///  ناشر 
        /// </summary>
        public string PublisherName { get; set; }

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        public string AuthersName { get; set; }

        /// <summary>
        ///  مترجم ها 
        /// </summary>
        public string TranslatorsName { get; set; }

        /// <summary>
        /// نرم افزار موردنیاز برای باز کردن فایل 
        /// </summary>
        public string SoftwareNeededToOpenFile { get; set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected Book()
        {
        }

        public override void Validate()
        {

        }
    }
}
