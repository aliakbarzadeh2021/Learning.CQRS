using System;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS .Messages.Command.LearningCenterModule.Messages.Items
{
    public class PrivilegeItem
    {
        /// <summary>
        ///  id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        ///  نوع دسترسی
        /// </summary>
        public AccessType AccessType { get; set; }

    }
}