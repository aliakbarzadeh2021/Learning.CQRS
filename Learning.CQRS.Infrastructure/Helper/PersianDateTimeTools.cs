using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CQRS.Infrastructure.Helper
{
    public static class PersianDateTimeTools
    {
        public static int GetPersianDayOfWeek(this DayOfWeek dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                    return 1;
                case DayOfWeek.Sunday:
                    return 2;
                case DayOfWeek.Monday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 4;
                case DayOfWeek.Wednesday:
                    return 5;
                case DayOfWeek.Thursday:
                    return 6;
                case DayOfWeek.Friday:
                    return 7;
                default:
                    return 1;
            }
        }
    }
}
