
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Messages.QueryModel;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument
{
    using AutoMapper;

    public class ElectronicDocumentMapperProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicDocumentMapperProfile"/> class.
        /// </summary>
        public ElectronicDocumentMapperProfile()
        {
            CreateMap<Privilege, IPrivilegeDto>();
            CreateMap<LeasonGrade, ILeasonGradeDto>();
            CreateMap<Confirmation, IConfirmationDto>();
            CreateMap<Book, IBookDto>();
            CreateMap<Magazin, IMagazinDto>();

        }
    }
}
