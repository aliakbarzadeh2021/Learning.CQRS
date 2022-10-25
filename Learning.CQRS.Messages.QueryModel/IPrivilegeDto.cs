using System;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Messages.QueryModel
{
    public interface IPrivilegeDto
    {
        /// <summary>
        ///  id
        /// </summary>
         Guid Id { get; set; }


        /// <summary>
        ///  نوع دسترسی
        /// </summary>
         AccessType AccessType { get; set; }

    }
}