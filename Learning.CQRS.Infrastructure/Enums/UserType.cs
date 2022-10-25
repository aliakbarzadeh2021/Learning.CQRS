
namespace Learning.CQRS.Infrastructure.Enums
{
    using System.ComponentModel;
    public enum UserType
    {
        [Description("موسسه")]
        Institute = 1,

        [Description("کارشناس")]
        Expert = 2,


        [Description("معلم")]
        Teacher = 3,

        [Description("مشاور")]
        Consultant = 4,

        [Description("دانش آموز")]
        Student = 5,

        [Description("والدین")]
        Parent = 6
    }
}
