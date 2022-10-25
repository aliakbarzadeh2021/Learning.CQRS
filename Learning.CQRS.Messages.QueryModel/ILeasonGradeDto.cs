using System;

namespace Learning.CQRS.Messages.QueryModel
{
    public interface ILeasonGradeDto
    {
        /// <summary>
        ///  Id
        /// </summary>
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