using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
    public class Booklet : ElectronicDocument, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Booklet"/> class.
        /// </summary>
        public Booklet(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc,  string publishingYear, string originalFile, FileType fileType, string publisherNameBooklet, string authersNameBooklet, string softwareNeededToOpenFileBooklet)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, publishingYear, originalFile, fileType)
        {
            PublisherNameBooklet = publisherNameBooklet;
            AuthersNameBooklet = authersNameBooklet;
            SoftwareNeededToOpenFileBooklet = softwareNeededToOpenFileBooklet;
        }

        /// <summary>
        ///  ناشر 
        /// </summary>
        public string PublisherNameBooklet { get; set; }

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        public string AuthersNameBooklet { get; set; }

        /// <summary>
        /// نرم افزار موردنیاز برایباز کردن فایل 
        /// </summary>
        public string SoftwareNeededToOpenFileBooklet { get; set; }


        /// <summary>
        /// For EF!
        /// </summary>
        protected Booklet()
        {
        }

        public override void Validate()
        {

        }
    }
}
