using System;
using Learning.CQRS.Infrastructure.Domain;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities
{
  public  class LeasonGrade : EntityBase<Guid>
    {
        public LeasonGrade(Guid id, int grade, string lessonName)
        {
            Id = id;
            Grade = grade;
            LessonName = lessonName;
        }


        /// <summary>
        ///  پایه 
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        ///  درس
        /// </summary>
        public string LessonName { get; set; }

        public override void Validate()
        {

        }
    }
}
