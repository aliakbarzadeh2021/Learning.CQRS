
using System.Data.Entity.ModelConfiguration;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;

namespace Learning.CQRS.Repository.Mappings
{
    public class ArticleMap : EntityTypeConfiguration<Article>
    {
        public ArticleMap()
        {
           
            Property(t => t.AuthersNameArticle).IsRequired();
            Property(t => t.ProviderOrganizationArticle).IsOptional();
            Property(t => t.OriginalAbstractfile).IsOptional();

            ToTable("Article");
        }
    }
}
