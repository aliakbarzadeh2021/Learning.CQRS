
using System.Collections.Generic;
using MassTransit;
using Learning.CQRS.CommandBus.Handling;
using Learning.CQRS.Repository.Write.Context.Interfaces;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.LabratoryAgg;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicDocument;

namespace Learning.CQRS.Handler.Modules.LearningCenterModule
{
    using System;
    using Infrastructure.Enums;

    public sealed class LabratoryCommandHandler : ICommandHandler<CreateBookCommand>
    {

        private readonly IRepository<InpersonLabratory> _inpersonLabratoryRepository;
        private readonly IRepository<VirtualLabratory> _virtualLabratoryRepository;

        private readonly IContext _context;
        private readonly IBus _bus;


        /// <summary>
        /// Initializes a new instance of the <see cref="LabratoryCommandHandler"/> class.
        /// </summary>
        public LabratoryCommandHandler(IContext context, IBus bus,
            IRepository<InpersonLabratory> inpersonLabratoryRepository,
            IRepository<VirtualLabratory> virtualLabratoryRepository)

        {
            _context = context;
            _bus = bus;
            _inpersonLabratoryRepository = inpersonLabratoryRepository;
            _virtualLabratoryRepository = virtualLabratoryRepository;
        }

        public void Handle(CreateBookCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
