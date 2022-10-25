
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class ThesisMap : EntityTypeConfiguration<Thesis>
    {
        public ThesisMap()
        {
           
            Property(t => t.AuthersNameThesis).IsRequired();
            Property(t => t.ProviderOrganizationThesis).IsOptional();

            ToTable("Thesis");
        }
    }
}
