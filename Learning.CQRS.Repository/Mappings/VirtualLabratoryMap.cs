
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class VirtualLabratoryMap : EntityTypeConfiguration<VirtualLabratory>
    {
        public VirtualLabratoryMap()
        {
            Property(t => t.Lable).IsRequired();
            Property(t => t.ProductionYearVirtualLab).IsRequired();


            ToTable("VirtualLabratory");
        }
    }
}
