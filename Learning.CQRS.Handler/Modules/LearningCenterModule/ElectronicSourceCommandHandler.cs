
using System.Collections.Generic;
using MassTransit;
using Learning.CQRS.CommandBus.Handling;
using Learning.CQRS.Repository.Write.Context.Interfaces;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicSourceAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicDocument;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicSource;

namespace Learning.CQRS.Handler.Modules.LearningCenterModule
{
    using System;
    using Infrastructure.Enums;

    public sealed class ElectronicSourceCommandHandler : ICommandHandler<CreateEducationalGameCommand>
    {

        private readonly IRepository<EducationalGame> _educationalGameRepository;
        private readonly IRepository<InformationBase> _informationBaseRepository;

        private readonly IContext _context;
        private readonly IBus _bus;

        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicSourceCommandHandler"/> class.
        /// </summary>
        public ElectronicSourceCommandHandler(IContext context, IBus bus,
            IRepository<EducationalGame> educationalGameRepository,
            IRepository<InformationBase> informationBaseRepository)
           
        {
            _context = context;
            _bus = bus;
            _educationalGameRepository = educationalGameRepository;
            _informationBaseRepository = informationBaseRepository;
        }

        public void Handle(CreateEducationalGameCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
