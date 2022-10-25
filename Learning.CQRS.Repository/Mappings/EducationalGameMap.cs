
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class EducationalGameMap : EntityTypeConfiguration<EducationalGame>
    {
        public EducationalGameMap()
        {
            Property(t => t.Instructions).IsRequired();
            Property(t => t.OriginalFileEduGame).IsRequired();
            Property(t => t.FileTypeEduGame).IsOptional();
            Property(t => t.ProductionYearEduGame).IsOptional();
            
            ToTable("EducationalGame");
        }
    }
}
