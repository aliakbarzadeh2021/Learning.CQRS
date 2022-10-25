
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.Items;

namespace Learning.CQRS.Messages.QueryModel.ElectronicDocument
{
    using QueryModel;
    using System;
    using System.Collections.Generic;
    public interface IBookDto
    {
        /// <summary>
        ///  OwnerId
        /// </summary>
        Guid OwnerId { get; set; }


        /// <summary>
        /// تاریخ ایجاد
        /// </summary>
        DateTime CreatedDateTime { get; set; }


        /// <summary>
        /// تاریخ آخرین بروزرسانی
        /// </summary>
        DateTime LastSavedDateTime { get; set; }


        /// <summary>
        ///  نام پیشنهاددهنده
        /// </summary>
        string ProposerName { get; set; }

        /// <summary>
        ///  عنوان
        /// </summary>
        string Title { get; set; }

        /// <summary>
        ///  کلیدواژه
        /// </summary>
        string Keyword { get; set; }

        /// <summary>
        ///  وضعیت
        /// </summary>
        Status Status { get; set; }


        /// <summary>
        /// نوع کاربری که منبع یادگیری را ثبت می کند
        /// </summary>
        UserType UserType { get; set; }

        /////////////////////////

        /// <summary>
        ///  سال نشر 
        /// </summary>
        string PublishingYear { get; set; }


        /// <summary>
        /// فایل اصلی
        /// </summary>
        string OriginalFile { get; set; }

        /// <summary>
        /// نوع فایل
        /// </summary>
        FileType FileType { get; set; }



        /// <summary>
        ///  ناشر 
        /// </summary>
        string PublisherName { get; set; }

        /// <summary>
        ///  نویسندگان 
        /// </summary>
        string AuthersName { get; set; }

        /// <summary>
        ///  مترجم ها 
        /// </summary>
        string TranslatorsName { get; set; }

        /// <summary>
        /// نرم افزار موردنیاز برای باز کردن فایل 
        /// </summary>
        string SoftwareNeededToOpenFile { get; set; }



        /// <summary>
        /// لیستی از نوع دسترسی
        /// </summary>
        ICollection<IPrivilegeDto> PrivilegeList { get; set; }


        /// <summary>
        /// لیستی از  پایه و درس
        /// </summary>
        ICollection<ILeasonGradeDto> LeasonGradeList { get; set; }


        /// <summary>
        /// تایید 
        /// </summary>
        IConfirmationDto Confirmationdoc { get; set; }
    }
}
