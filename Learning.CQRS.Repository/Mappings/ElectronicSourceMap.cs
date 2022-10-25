
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg.Abstract;

namespace Learning.CQRS.Repository.Mappings
{
    public class ElectronicSourceMap : EntityTypeConfiguration<ElectronicSource>
    {
        public ElectronicSourceMap()
        {
            HasKey(t => t.Id);
            Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(t => t.SubjectSource).IsRequired();


        }
    }
}
