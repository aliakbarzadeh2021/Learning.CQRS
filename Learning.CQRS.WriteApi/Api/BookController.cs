
namespace Learning.CQRS.WriteApi.Api
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Messages.Command.LearningCenterModule.Messages.ElectronicDocument;
    using Activator.SeedWorks.Core;
    using Activator.SeedWorks.Models;
    using Kernel.CommandBus;
    using Kernel.Infrastructure.Domain;
    using Kernel.Infrastructure.Exceptions;

    public  class BookController: ApiControllerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookController"/> class.
        /// </summary>
        public BookController(ICommandBus bus) : base(bus)
        {
        }
        /// <summary>
        ///  ایجاد مباع یادگیری کتاب
        /// </summary>
        /// <param name="command">command</param>
        /// <returns>HttpResponseMessage</returns>
#pragma warning disable 1998
        public async Task<HttpResponseMessage> Post(CreateBookCommand command)
#pragma warning restore 1998
        {
            try
            {
                command.Validate();
                Bus.Send(command);
                return Request.CreateResponse(HttpStatusCode.OK,
                  CreateResponseModel("ثبت منابع یادگیری کتاب با موفقیت انجام شد ", ResponseMessageType.Success, true));
            }
            catch (CommandValidationException validationException)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    CreateResponseModel(validationException.Message, ResponseMessageType.Warning));
            }
            catch (DomainException domainException)
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    CreateResponseModel(domainException.Message, ResponseMessageType.Warning));
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.OK,
                    CreateResponseModel(string.Format("ثبت  منابع یادگیری کتاب  با مشکل مواجه شده است"),
                        ResponseMessageType.Error));
            }
        }
    }
}
