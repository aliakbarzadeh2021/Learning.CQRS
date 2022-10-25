
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg.Abstract;

namespace Learning.CQRS.Repository.Mappings
{
    public class LabratoryMap : EntityTypeConfiguration<Labratory>
    {
        public LabratoryMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.ManufacturerLabratory).IsOptional();
            Property(t => t.InstructionsLabratory).IsOptional();
            Property(t => t.SubjectLab).IsRequired();

        }
    }
}
