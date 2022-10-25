
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg;
using Learning.CQRS.Messages.QueryModel.ElectronicSource;
using Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Services
{
    using Interface.LearningCenterModule;
    using Kernel.Repository.Read.Context.Interfaces;

    // <inheritdoc />
    internal class ElectronicSourceQueryService : IElectronicSourceQueryService
    {
        /// <summary>
        /// _educationalGameRepository
        /// </summary>
        private readonly IReadOnlyRepository<EducationalGame> _educationalGameRepository;

        /// <summary>
        /// _informationBaseRepository
        /// </summary>
        private readonly IReadOnlyRepository<InformationBase> _informationBaseRepository;


        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicSourceQueryService"/> class.
        /// </summary>
        public ElectronicSourceQueryService(IReadOnlyRepository<EducationalGame> educationalGameRepository, IReadOnlyRepository<InformationBase> informationBaseRepository)
        {
            _educationalGameRepository = educationalGameRepository;
            _informationBaseRepository = informationBaseRepository;

        }

        // <inheritdoc />
        public IEducationalGameDto GetEducationalGames()
        {
            return _educationalGameRepository.Find().ToDto();
        }

        // <inheritdoc />
        public IInformationBaseDto GetInformationBases()
        {
            return _informationBaseRepository.Find().ToDto();
        }

    }
}
