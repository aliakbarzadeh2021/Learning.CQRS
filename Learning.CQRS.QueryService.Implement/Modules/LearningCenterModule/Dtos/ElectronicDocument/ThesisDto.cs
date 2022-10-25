using System;
using System.Collections.Generic;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Dtos.ElectronicDocument
{

    public class ThesisDto : IThesisDto
    {
        /// <inheritdoc />
        public Guid Id { get; set; }

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
        public virtual ICollection<Privilege> Privileges { get; set; }


        /// <summary>
        /// لیستی از  پایه و درس
        /// </summary>
        public virtual ICollection<LeasonGrade> LeasonGradeList { get; set; }

        /// <summary>
        ///   فایل 
        /// </summary>
        public string OriginalFile { get; set; }
    }
}
