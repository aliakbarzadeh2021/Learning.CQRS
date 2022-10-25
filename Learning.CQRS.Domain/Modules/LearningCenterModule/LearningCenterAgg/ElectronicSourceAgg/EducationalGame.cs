using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg.Abstract;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg
{
    public class EducationalGame : ElectronicSource, IAggregateRoot
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EducationalGame"/> class.
        /// </summary>
        public EducationalGame(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc, string subjectSource, string instructions, int productionYearEduGame, string originalFileEduGame, FileType fileTypeEduGame)
            : base(id, ownerId, createdDateTime, lastSavedDateTime, proposerName, title, keyword, status, userType, confirmationdoc, subjectSource)
        {
            Instructions = instructions;
            ProductionYearEduGame = productionYearEduGame;
            OriginalFileEduGame = originalFileEduGame;
            FileTypeEduGame = fileTypeEduGame;
        } 

        /// <summary>
        /// دستورالعمل
        /// </summary>
        public string Instructions { get; set; }

        /// <summary>
        ///  سال تولید 
        /// </summary>
        public int ProductionYearEduGame { get; set; }


        /// <summary>
        /// فایل اصلی
        /// </summary>
        public string OriginalFileEduGame { get; private set; }

        /// <summary>
        /// نوع فایل
        /// </summary>
        public FileType FileTypeEduGame { get; private set; }


        /// <summary>
        /// For EF!
        /// </summary>
        protected EducationalGame()
        {
        }

        public override void Validate()
        {

        }
    }
}
