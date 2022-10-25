using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract
{
    using LearningCenterAgg.Abstract;
    /// <summary>
    /// مرکز یادگیری
    /// </summary>
    public abstract class ElectronicDocument : LearningCenter, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicDocument"/> class.
        /// </summary>
        protected ElectronicDocument(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear, string originalFile, FileType fileType)
                          : base( id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc)
        {
            PublishingYear = publishingYear;
            OriginalFile = originalFile;
            FileType = fileType;
        }


        /// <summary>
        ///  سال نشر 
        /// </summary>
        public string PublishingYear { get; set; }


        /// <summary>
        /// فایل اصلی
        /// </summary>
        public string OriginalFile { get; private set; }

        /// <summary>
        /// نوع فایل
        /// </summary>
        public FileType FileType { get; private set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected ElectronicDocument()
        {
        }

        public override void Validate()
        {

        }
    }
}
