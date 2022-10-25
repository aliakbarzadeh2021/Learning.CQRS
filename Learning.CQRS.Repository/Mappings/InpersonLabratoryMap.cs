
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class InpersonLabratoryMap : EntityTypeConfiguration<InpersonLabratory>
    {
        public InpersonLabratoryMap()
        {
            Property(t => t.SoftwareNeededToOpenFileInpersonLab).IsRequired();
         
            ToTable("InpersonLabratory");
        }
    }
}
