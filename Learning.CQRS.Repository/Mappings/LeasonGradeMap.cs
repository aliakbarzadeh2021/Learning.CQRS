
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;

namespace Learning.CQRS.Repository.Mappings
{
    public class LeasonGradeMap : EntityTypeConfiguration<LeasonGrade>
    {
        public LeasonGradeMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.Grade).IsRequired();
            Property(t => t.LessonName).IsRequired();
            ToTable("LeasonGrade");
        }
    }
}
