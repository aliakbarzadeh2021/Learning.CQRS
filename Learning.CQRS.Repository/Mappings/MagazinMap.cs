
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class MagazinMap : EntityTypeConfiguration<Magazin>
    {
        public MagazinMap()
        {
            Property(t => t.PlacePublication).IsRequired();
            Property(t => t.ChiefEditor).IsRequired();
            Property(t => t.Concessionaire).IsRequired();
            Property(t => t.DirectoreResponsible).IsRequired();
            Property(t => t.UrlMagazin).IsRequired();


            ToTable("Magazin");
        }
    }
}
