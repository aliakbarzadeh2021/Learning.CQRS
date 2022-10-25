
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;

namespace Learning.CQRS.Repository.Mappings
{
    public class PrivilegeMap : EntityTypeConfiguration<Privilege>
    {
        public PrivilegeMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.AccessType).IsRequired();
           
            ToTable("Privilege");
        }
    }
}
