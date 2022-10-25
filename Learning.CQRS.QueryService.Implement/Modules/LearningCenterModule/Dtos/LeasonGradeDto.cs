using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Messages.QueryModel;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Dtos
{
   public  class LeasonGradeDto: ILeasonGradeDto
    {

        /// <inheritdoc />
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
