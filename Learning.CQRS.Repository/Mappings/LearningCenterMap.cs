using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Learning.CQRS.Repository.Mappings
{
    public class LearningCenterMap : EntityTypeConfiguration<Domain.Modules.LearningCenterModule.LearningCenterAgg.Abstract.LearningCenter>
    {
        public LearningCenterMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.ProposerName).IsRequired();
            Property(t => t.Title).IsRequired();
            Property(t => t.Keyword).IsOptional();
            Property(t => t.Status).IsRequired();
            Property(t => t.CreatedDateTime).IsRequired();
            Property(t => t.LastSavedDateTime).IsRequired();
            Property(t => t.UserType).IsRequired();
            HasMany(t => t.Privileges);
            HasMany(t => t.LeasonGradeList);
        }
    }
}
