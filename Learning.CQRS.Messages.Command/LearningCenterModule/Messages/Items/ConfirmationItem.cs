using System;

namespace Learning.CQRS .Messages.Command.LearningCenterModule.Messages.Items
{
    public class ConfirmationItem
    {
        /// <summary>
        ///  Id
        /// </summary>
        public Guid Id { get; set; }


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
        public virtual ConfirmationItem Confirmationdoc { get; set; }

    }
}