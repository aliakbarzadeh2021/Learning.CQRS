using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
    public class Multimedia : ElectronicDocument, IAggregateRoot
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Multimedia"/> class.
        /// </summary>
        public Multimedia(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear, string originalFile, FileType fileType, string manifacturersName, string softwareNeededToOpenMultimediaFile)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, publishingYear, originalFile, fileType)
        {
            ManifacturersName = manifacturersName;
            SoftwareNeededToOpenMultimediaFile = softwareNeededToOpenMultimediaFile;
        }


        /// <summary>
        ///  تولیدکنندگان  
        /// </summary>
        public string ManifacturersName { get; set; }


        /// <summary>
        /// نرم افزار موردنیاز برایباز کردن فایل 
        /// </summary>
        public string SoftwareNeededToOpenMultimediaFile { get; set; }

        /// <summary>
        /// For EF!
        /// </summary>
        protected Multimedia()
        {
        }

        public override void Validate()
        {

        }
    }
}
