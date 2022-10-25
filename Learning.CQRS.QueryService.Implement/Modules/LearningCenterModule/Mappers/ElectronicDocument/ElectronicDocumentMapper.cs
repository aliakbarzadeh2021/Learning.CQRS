
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.QueryService.Implement.Modules.LearningCenterModule.Mappers.ElectronicDocument
{
    using AutoMapper;
    /// <summary>
    /// Mapper book
    /// </summary>
    internal static class ElectronicDocumentMapper
    {
        /// <summary>
        /// IBookDto به book نگاشت
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>IBookDto</returns>
        public static IBookDto ToDto(this Book book)
        {
            return Mapper.Map<IBookDto>(book);
        }

        /// <summary>
        /// IMagazinDto به magazin نگاشت
        /// </summary>
        /// <param name="magazin">book</param>
        /// <returns>IMagazinDto</returns>
        public static IMagazinDto ToDto(this Magazin magazin)
        {
            return Mapper.Map<IMagazinDto>(magazin);
        }



        /// <summary>
        /// IArticleDto به article نگاشت
        /// </summary>
        /// <param name="article">book</param>
        /// <returns>IArticleDto</returns>
        public static IArticleDto ToDto(this Article article)
        {
            return Mapper.Map<IArticleDto>(article);
        }


        /// <summary>
        /// IThesisDto به thesis نگاشت
        /// </summary>
        /// <param name="thesis">book</param>
        /// <returns>IThesisDto</returns>
        public static IThesisDto ToDto(this Thesis thesis)
        {
            return Mapper.Map<IThesisDto>(thesis);
        }


        /// <summary>
        /// IMultimediaDto به multimedia نگاشت
        /// </summary>
        /// <param name="multimedia">multimedia</param>
        /// <returns>IMultimediaDto</returns>
        public static IMultimediaDto ToDto(this Multimedia multimedia)
        {
            return Mapper.Map<IMultimediaDto>(multimedia);
        }

        /// <summary>
        /// IBookDto به book نگاشت
        /// </summary>
        /// <param name="book">book</param>
        /// <returns>IBookDto</returns>
        public static IBookletDto ToDto(this Booklet book)
        {
            return Mapper.Map<IBookletDto>(book);
        }
     
    }
}
