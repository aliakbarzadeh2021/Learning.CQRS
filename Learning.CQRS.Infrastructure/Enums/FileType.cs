
namespace Learning.CQRS.Infrastructure.Enums
{
    using System.ComponentModel;
    public enum FileType
    {
        [Description("عکس")]
        Picture = 1,

        [Description("صوت")]
        Audio = 2,

        [Description("فیلم")]
        Movie = 3,

        [Description("پی دی اف")]
        Pdf = 4,

        [Description("ورد")]
        Word = 5,

        [Description("پاورپوینت")]
        PowerPoint = 6,
        
        [Description("اکسل")]
        Excel = 7
    }
}
