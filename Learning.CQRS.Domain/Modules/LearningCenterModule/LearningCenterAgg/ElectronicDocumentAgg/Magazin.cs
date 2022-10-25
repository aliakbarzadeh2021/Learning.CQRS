using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg
{
    public class Magazin: ElectronicDocument, IAggregateRoot
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Magazin"/> class.
        /// </summary>
        public Magazin(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string publishingYear, string originalFile, FileType fileType, string placePublication, string concessionaire, string directoreResponsible, string chiefEditor, string urlMagazin) 
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc,  publishingYear, originalFile, fileType)
        {
            PlacePublication = placePublication;
            Concessionaire = concessionaire;
            DirectoreResponsible = directoreResponsible;
            ChiefEditor = chiefEditor;
            UrlMagazin = urlMagazin;
        }

        /// <summary>
        ///  محل انتشار 
        /// </summary>
        public string PlacePublication { get; set; }


        /// <summary>
        ///  صاحب امتیاز 
        /// </summary>
        public string Concessionaire { get; set; }


        /// <summary>
        ///  مدیرمسئول  
        /// </summary>
        public string DirectoreResponsible { get; set; }

        /// <summary>
        ///  سردبیر  
        /// </summary>
        public string ChiefEditor { get; set; }


        /// <summary>
        ///    Urlمجله
        /// </summary>
        public string UrlMagazin { get; set; }



        /// <summary>
        /// For EF!
        /// </summary>
        protected Magazin()
        {
        }

        public override void Validate()
        {

        }
    }
}
