
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg.Abstract;

namespace Learning.CQRS.Repository.Mappings
{
    public class ElectronicDocumentMap : EntityTypeConfiguration<ElectronicDocument>
    {
        public ElectronicDocumentMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.PublishingYear).IsOptional();
            Property(t => t.OriginalFile).IsRequired();
            Property(t => t.FileType).IsRequired();
            ToTable(" ElectronicDocument");
        }
    }
}
