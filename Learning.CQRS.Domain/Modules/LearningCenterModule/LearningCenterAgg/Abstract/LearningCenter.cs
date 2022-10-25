using System;
using System.Collections.Generic;
using Learning.CQRS.Infrastructure.Domain;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Infrastructure.Enums;

namespace Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Abstract
{
    public abstract class LearningCenter : EntityBase<Guid>, IAggregateRoot
    {
        protected LearningCenter(Guid id, Guid ownerId, DateTime createdDateTime, DateTime lastSavedDateTime, string proposerName, string title, string keyword, Status status, UserType userType, Confirmation confirmationdoc)
        {
            Id = id;
            OwnerId = ownerId;
            CreatedDateTime = createdDateTime;
            LastSavedDateTime = lastSavedDateTime;
            ProposerName = proposerName;
            Title = title;
            Keyword = keyword;
            Status = status;
            UserType = userType;
            Confirmationdoc = confirmationdoc;
        }


        /// <summary>
        ///  OwnerId
        /// </summary>
        public Guid OwnerId { get; set; }


        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        public DateTime CreatedDateTime { get; set; }


        /// <summary>
        /// تاریخ آخرین بروزرسانی
        /// </summary>
        public DateTime LastSavedDateTime { get; set; }


        /// <summary>
        ///  نام پیشنهاددهنده
        /// </summary>
        public string ProposerName { get; set; }

        /// <summary>
        ///  عنوان
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///  کلیدواژه
        /// </summary>
        public string Keyword { get; set; }

        /// <summary>
        ///  وضعیت
        /// </summary>
        public Status Status { get; set; }


        /// <summary>
        /// نوع کاربری که منبع یادگیری را ثبت می کند
        /// </summary>
        public UserType UserType { get; set; }


        /// <summary>
        /// لیستی از نوع دسترسی
        /// </summary>
        public virtual ICollection<Privilege> Privileges { get; set; }


        /// <summary>
        /// لیستی از  پایه و درس
        /// </summary>
        public virtual ICollection<LeasonGrade> LeasonGradeList { get; set; }


        /// <summary>
        /// تایید 
        /// </summary>
        public virtual Confirmation Confirmationdoc { get; set; }



        /// <summary>
        /// For EF!
        /// </summary>
        protected LearningCenter()
        {
        }

        public override void Validate()
        {

        }

    }
}
