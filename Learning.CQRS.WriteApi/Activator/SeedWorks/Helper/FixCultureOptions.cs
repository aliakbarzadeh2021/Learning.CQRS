using System;

namespace Learning.CQRS.WriteApi.Activator.SeedWorks.Helper
{
    [Flags]
    public enum FixCultureOptions
    {
        /// <summary>
        /// If set Calendar property of culture will be set to PersianCalendar.
        /// </summary>
        FoptCalendarInCulture = 2,
        /// <summary>
        /// If set Calendar of DateFormatInfo will be set to PersianCalendar
        /// </summary>
        FoptCalendarInDateFormatInfo = 4,
        /// <summary>
        /// If set the first element of OptionalCalendars will be set to PersianCalendar
        /// </summary>
        FoptOptionalCalendars = 8,
        /// <summary>
        /// All fix ups will applied.
        /// </summary>
        FoptAll = 16
    }
}
