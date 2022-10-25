using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Learning.CQRS.Infrastructure.Helper
{
    public class PersianNationalHoliday
    {
        public PersianNationalHoliday(int year)
        {
            var persianCalendar = new PersianCalendar();
            //init
            Days = new List<DateTime>();
            var firstDate = persianCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0);
            while (firstDate.DayOfWeek != DayOfWeek.Friday)
            {
                firstDate = firstDate.AddDays(1);
            }
            var friday = firstDate;
            //تعطیلات رسمی تقویم شمسی
            var days = new List<DateTime>
            {
                persianCalendar.ToDateTime(year, 1, 1, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 1, 2, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 1, 3, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 1, 4, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 1, 12, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 1, 13, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 3, 14, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 3, 15, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 11, 22, 0, 0, 0, 0),
                persianCalendar.ToDateTime(year, 12, 29, 0, 0, 0, 0)
            };
            //تعطیلات جمعه
            do
            {
                if (!days.Contains(friday))
                {
                    days.Add(friday);
                }
                friday = friday.AddDays(7);
            } while (persianCalendar.GetYear(friday) == year);

            Days = days.OrderBy(o => o).ToList();

        }

        public IEnumerable<DateTime> Days { get; private set; }
    }
}
