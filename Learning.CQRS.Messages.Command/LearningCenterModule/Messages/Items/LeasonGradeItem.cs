using System;

namespace Learning.CQRS .Messages.Command.LearningCenterModule.Messages.Items
{
    public class LeasonGradeItem
    {
        /// <summary>
        ///  Id
        /// </summary>
        public Guid Id { get; set; }


        /// <summary>
        ///  پایه 
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        ///  درس
        /// </summary>
        public string LessonName { get; set; }

    }
}