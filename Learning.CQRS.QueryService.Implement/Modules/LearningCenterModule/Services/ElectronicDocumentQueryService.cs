
namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Services
{
    using Interface.LearningCenterModule;
    using Kernel.Repository.Read.Context.Interfaces;
    using Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
    using Messages.QueryModel.ElectronicDocument;
    using Mappers.ElectronicDocument;

    // <inheritdoc />
    internal class ElectronicDocumentQueryService : IElectronicDocumentQueryService
    {
        /// <summary>
        /// _bookRepository
        /// </summary>
        private readonly IReadOnlyRepository<Book> _bookRepository;

        /// <summary>
        /// _magazinRepository
        /// </summary>
        private readonly IReadOnlyRepository<Magazin> _magazinRepository;

        /// <summary>
        /// _articleRepository
        /// </summary>
        private readonly IReadOnlyRepository<Article> _articleRepository;

        /// <summary>
        /// _thesisRepository
        /// </summary>
        private readonly IReadOnlyRepository<Thesis> _thesisRepository;

        /// <summary>
        /// _book_multimediaRepositoryRepository
        /// </summary>
        private readonly IReadOnlyRepository<Multimedia> _multimediaRepository;

        /// <summary>
        /// _bookletRepository
        /// </summary>
        private readonly IReadOnlyRepository<Booklet> _bookletRepository;



        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicDocumentQueryService"/> class.
        /// </summary>
        public ElectronicDocumentQueryService(IReadOnlyRepository<Book> bookRepository, IReadOnlyRepository<Magazin> magazinRepository,
                                              IReadOnlyRepository<Article> articleRepository, IReadOnlyRepository<Thesis> thesisRepository, 
                                              IReadOnlyRepository<Multimedia> multimediaRepository, IReadOnlyRepository<Booklet> bookletRepository)
        {
            _bookRepository = bookRepository;
            _magazinRepository = magazinRepository;
            _articleRepository = articleRepository;
            _thesisRepository = thesisRepository;
            _multimediaRepository = multimediaRepository;
            _bookletRepository = bookletRepository;
        }

        // <inheritdoc />
        public IBookDto GetBooks()
        {
            return _bookRepository.Find().ToDto();
        }

        // <inheritdoc />
        public IMagazinDto GetMagazins()
        {
            return _magazinRepository.Find().ToDto();
        }

        // <inheritdoc />
        public IArticleDto GetArticles()
        {
            return _articleRepository.Find().ToDto();
        }

        // <inheritdoc />
        public IThesisDto GetThesises()
        {
            return _thesisRepository.Find().ToDto();
        }
        // <inheritdoc />
        public IMultimediaDto GetMultimedia()
        {
            return _multimediaRepository.Find().ToDto();
        }

        // <inheritdoc />
        public IBookletDto GetBooklets()
        {
            return _bookletRepository.Find().ToDto();
        }

    }
}
