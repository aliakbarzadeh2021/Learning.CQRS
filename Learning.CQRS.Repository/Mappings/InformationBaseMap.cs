
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class InformationBaseMap : EntityTypeConfiguration<InformationBase>
    {
        public InformationBaseMap()
        {
            Property(t => t.UrlInformationBase).IsRequired();
            Property(t => t.ConcessionaireInformationBase).IsRequired();
           
            ToTable("InformationBase");
        }
    }
}
