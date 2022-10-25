using System;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities
{
   public class Confirmation : EntityBase<Guid>
    {
        protected Confirmation(Guid id, int scoreForCreator, int scoreForProposer, string disApprovalReason, Confirmation confirmationdoc)
        {
            Id = id;
            ScoreForCreator = scoreForCreator;
            ScoreForProposer = scoreForProposer;
            DisApprovalReason = disApprovalReason;
            Confirmationdoc = confirmationdoc;
        }
       
        /// <summary>
        ///  تایید کننده
        /// </summary>
        public int ConfirmerId { get; set; }

        /// <summary>
        ///  امتیاز برای تولیدکننده
        /// </summary>
        public int ScoreForCreator { get; set; }

        /// <summary>
        ///  امتیاز برای پیشنهاددهنده
        /// </summary>
        public int ScoreForProposer { get; set; }

        /// <summary>
        ///  دلیل عدم تایید
        /// </summary>
        public string DisApprovalReason { get; set; }


        /// <summary>
        ///  selfConfirmation
        /// </summary>
        public virtual Confirmation Confirmationdoc { get; set; }


        public override void Validate()
        {

        }
    }
}
