using System;
using System.Collections.Generic;
using Learning.CQRS.CommandBus.Messages;
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.Items;
using Learning.CQRS.Messages.Command.LearningCenterModule.Validators.ElectronicDocument;
using Learning.CQRS.Messages.Command.Seedworks;

namespace Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicDocument
{
   public class CreateBookCommand: CommandBase
    {


        /// <summary>
        /// Id
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// OwnerId
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
        ///  ناشر 
        /// </summary>
        public string PublisherName { get; set; }


        /// <summary>
        ///  سال نشر 
        /// </summary>
        public string PublishingYear { get; set; }

        

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        public string AuthersName { get; set; }

        /// <summary>
        ///  مترجم ها 
        /// </summary>
        public string TranslatorsName { get; set; }

        /// <summary>
        /// نرم افزار موردنیاز برای باز کردن فایل 
        /// </summary>
        public string SoftwareNeededToOpenFile { get; set; }


        /// <summary>
        /// لیستی از نوع دسترسی
        /// </summary>
        public virtual ICollection<PrivilegeItem> Privileges { get; set; }


        /// <summary>
        /// لیستی از  پایه و درس
        /// </summary>
        public virtual ICollection<LeasonGradeItem> LeasonGradeList { get; set; }

        /// <summary>
        ///   فایل 
        /// </summary>
        public string OriginalFile { get; set; }

        /// <summary>
        ///   نوع محتوا 
        /// </summary>
        public FileType FileType { get; set; }


        /// <summary>
        ///  نوع کاربر 
        /// </summary>
        public UserType UserType { get; set; }


        ///// <summary>
        ///// تایید 
        ///// </summary>
        //public virtual ConfirmationItem Confirmationdoc { get; set; }

        /// <summary>
        /// بررسی پروپرتی ها
        /// </summary>
        public override void Validate()
        {
            new CreateBookCommandValidator().Validate(this).RaiseExceptionIfRequired();
        }
    }
}
