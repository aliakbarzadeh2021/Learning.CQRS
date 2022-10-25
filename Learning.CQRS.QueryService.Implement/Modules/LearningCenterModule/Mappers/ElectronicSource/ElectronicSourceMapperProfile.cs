
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument
{
    using AutoMapper;

    public class ElectronicSourceMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicSourceMapperProfile"/> class.
        /// </summary>
        public ElectronicSourceMapperProfile()
        {
            CreateMap<Book, IBookDto>();
            CreateMap<Magazin, IMagazinDto>();

        }
    }
}
