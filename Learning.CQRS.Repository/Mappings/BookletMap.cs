
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class BookletMap : EntityTypeConfiguration<Booklet>
    {
        public BookletMap()
        {
            Property(t => t.PublisherNameBooklet).IsRequired();
            Property(t => t.AuthersNameBooklet).IsRequired();
            Property(t => t.SoftwareNeededToOpenFileBooklet).IsOptional();
            
            ToTable("Booklet");
        }
    }
}
