
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class BookMap : EntityTypeConfiguration<Book>
    {
        public BookMap()
        {
            Property(t => t.PublisherName).IsRequired();
            Property(t => t.AuthersName).IsRequired();
            Property(t => t.TranslatorsName).IsOptional();
            Property(t => t.SoftwareNeededToOpenFile).IsOptional();
            
            ToTable("Book");
        }
    }
}
