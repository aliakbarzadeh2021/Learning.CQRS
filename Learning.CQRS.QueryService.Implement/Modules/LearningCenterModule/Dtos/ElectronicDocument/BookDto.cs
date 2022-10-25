using System;
using System.Collections.Generic;
using Learning.CQRS.Infrastructure.Enums;
using Learning.CQRS.Messages.QueryModel;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Dtos.ElectronicDocument
{

    public class BookDto : IBookDto
    {

        /// <inheritdoc />
        public Guid Id { get; set; }
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
        ///  سال نشر 
        /// </summary>
        public string PublishingYear { get; set; }


        /// <summary>
        /// فایل اصلی
        /// </summary>
        public string OriginalFile { get;  set; }

        /// <summary>
        /// نوع فایل
        /// </summary>
        public FileType FileType { get;  set; }



        /// <summary>
        ///  ناشر 
        /// </summary>
        public string PublisherName { get; set; }

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

        public ICollection<IPrivilegeDto> PrivilegeList { get; set; }

        public ICollection<ILeasonGradeDto> LeasonGradeList { get; set; }

        public IConfirmationDto Confirmationdoc { get; set; }

    }
}
