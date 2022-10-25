
namespace Learning.CQRS.Infrastructure.Enums
{
    using System.ComponentModel;
    public enum Status
    {
        [Description("در حال بررسی")]
        Verrifing = 1,

        [Description("تایید شده")]
        Cinfirmed = 2,

        [Description("تایید نشده")]
        UnCinfirmed = 3 ,

    }
}
