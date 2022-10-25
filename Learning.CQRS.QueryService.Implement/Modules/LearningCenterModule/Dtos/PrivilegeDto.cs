using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Messages.QueryModel;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Dtos
{
   public  class PrivilegeDto: IPrivilegeDto
    {

        /// <inheritdoc />
        public Guid Id { get; set; }


        /// <summary>
        ///  نوع دسترسی
        /// </summary>
        public AccessType AccessType { get; set; }
    }
}
