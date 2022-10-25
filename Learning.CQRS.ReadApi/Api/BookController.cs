using System;
using System.Threading.Tasks;
using System.Web.Http;
using Learning.CQRS.QueryService.Interface.LearningCenterModule;
using Learning.CQRS.Messages.QueryModel.ElectronicDocument;

namespace Learning.CQRS.ReadApi.Api
{
    public class BookController: ApiController
    {
        private readonly IElectronicDocumentQueryService _electronicDocumentQueryService;
        public BookController(IElectronicDocumentQueryService electronicDocumentQueryService)
        {
            _electronicDocumentQueryService = electronicDocumentQueryService;
        }

        /// <summary>
        /// برگرداندن  کتاب ها
        /// </summary>
        /// <returns></returns>
#pragma warning disable 1998
        public async Task<IBookDto> Get()
#pragma warning restore 1998
        {
            return _electronicDocumentQueryService.GetBooks();
        }
    }
}
