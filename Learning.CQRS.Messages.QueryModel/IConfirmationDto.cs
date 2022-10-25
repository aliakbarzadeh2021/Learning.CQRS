using System;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Messages.QueryModel
{
    public interface IConfirmationDto
    {
        /// <inheritdoc />
         Guid Id { get; set; }

        /// <summary>
        ///  پایه 
        /// </summary>
         int Grade { get; set; }

        /// <summary>
        ///  درس
        /// </summary>
         string LessonName { get; set; }

    }
}