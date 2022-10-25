
using Learning.CQRS.Messages.QueryModel.ElectronicSource;

namespace Learning.CQRS.QueryService.Interface.LearningCenterModule
{
    /// <summary>
    /// کوری سرویس مربوط به ElectronicSource
    /// </summary>
    public interface IElectronicSourceQueryService
    {
        /// <summary>
        /// برگرداندن باز های آموزشی
        /// </summary>
        /// <returns>IEducationalGameDto</returns>
        IEducationalGameDto GetEducationalGames();


        /// <summary>
        /// برگرداندن پایگاه های اطلاعاتی
        /// </summary>
        /// <returns>IInformationBaseDto</returns>
        IInformationBaseDto GetInformationBases();


    }



}
