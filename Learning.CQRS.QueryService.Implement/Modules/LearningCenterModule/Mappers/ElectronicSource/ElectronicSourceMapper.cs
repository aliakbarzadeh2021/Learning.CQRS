
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;
using Learning.CQRS.Messages.QueryModel.ElectronicSource;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument
{
    using AutoMapper;
    /// <summary>
    /// Mapper book
    /// </summary>
    internal static class ElectronicSourceMapper
    {
        /// <summary>
        /// IEducationalGameDto به educationalGame نگاشت
        /// </summary>
        /// <param name="educationalGame">educationalGame</param>
        /// <returns>IBookDto</returns>
        public static IEducationalGameDto ToDto(this EducationalGame educationalGame)
        {
            return Mapper.Map<IEducationalGameDto>(educationalGame);
        }

        /// <summary>
        /// IInformationBaseDto به informationBase نگاشت
        /// </summary>
        /// <param name="informationBase">informationBase</param>
        /// <returns>IInformationBaseDto</returns>
        public static IInformationBaseDto ToDto(this InformationBase informationBase)
        {
            return Mapper.Map<IInformationBaseDto>(informationBase);
        }
     
    }
}
