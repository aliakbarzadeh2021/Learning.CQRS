using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Interface.LearningCenterModule
{
    /// <summary>
    /// کوری سرویس مربوط به ElectronicDocument
    /// </summary>
    public interface IElectronicDocumentQueryService
    {
        /// <summary>
        /// برگرداندن کتاب ها
        /// </summary>
        /// <returns>IBookDto</returns>
        IBookDto GetBooks();


        /// <summary>
        /// برگرداندن مجله ها
        /// </summary>
        /// <returns>IBookDto</returns>
        IMagazinDto GetMagazins();

        /// <summary>
        /// برگرداندن مقاله ها
        /// </summary>
        /// <returns>IBookDto</returns>
        IArticleDto GetArticles();

        /// <summary>
        /// برگرداندن پایان نامه ها
        /// </summary>
        /// <returns>IBookDto</returns>
        IThesisDto GetThesises();

        /// <summary>
        /// برگرداندن مالتی مدیا ها
        /// </summary>
        /// <returns>IBookDto</returns>
        IMultimediaDto GetMultimedia();

        /// <summary>
        /// برگرداندن جزوه های آموزشی
        /// </summary>
        /// <returns>IBookDto</returns>
        IBookletDto GetBooklets();
    }
}
