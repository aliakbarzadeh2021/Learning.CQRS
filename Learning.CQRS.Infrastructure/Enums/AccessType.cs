
namespace Learning.CQRS.Infrastructure.Enums
{
    using System.ComponentModel;
    public enum AccessType
    {
        [Description("معلمان")]
        Teacher = 1,

        [Description("مشاورها")]
        Consultant = 2,

        [Description("دانش آموزان")]
        Student = 3,

       [Description("والدین")]
        Parent = 4
    }
}
