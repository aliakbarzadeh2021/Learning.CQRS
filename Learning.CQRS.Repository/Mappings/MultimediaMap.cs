
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class MultimediaMap : EntityTypeConfiguration<Multimedia>
    {
        public MultimediaMap()
        {
            Property(t => t.FileType).IsRequired();
            Property(t => t.ManifacturersName).IsRequired();
            Property(t => t.SoftwareNeededToOpenMultimediaFile).IsRequired();


            ToTable("Multimedia");
        }
    }
}
