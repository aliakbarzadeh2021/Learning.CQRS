
using System.Collections.Generic;
using MassTransit;
using Learning.CQRS.CommandBus.Handling;
using Learning.CQRS.Repository.Write.Context.Interfaces;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.ElectronicDocumentAgg;
using Learning.CQRS.Domain.Modules.LearningCenterModule.LearningCenterAgg.Entities;
using Learning.CQRS.Messages.Command.LearningCenterModule.Messages.ElectronicDocument;

namespace Learning.CQRS.Handler.Modules.LearningCenterModule
{
    using Infrastructure.Enums;
    using System;

    public sealed class ElectronicDocumentCommandHandler : ICommandHandler<CreateBookCommand>
    {

        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Magazin> _magazinRepository;
        private readonly IRepository<Article> _articleRepository;
        private readonly IRepository<Thesis> _thesisRepository;
        private readonly IRepository<Multimedia> _multimediaRepository;
        private readonly IRepository<Booklet> _bookletRepository;

        private readonly IContext _context;
        private readonly IBus _bus;


        /// <summary>
        /// Initializes a new instance of the <see cref="ElectronicDocumentCommandHandler"/> class.
        /// </summary>
        public ElectronicDocumentCommandHandler(IContext context, IBus bus,
            IRepository<Book> bookRepository,
            IRepository<Magazin> magazinRepository,
            IRepository<Article> articleRepository,
            IRepository<Thesis> thesisRepository,
            IRepository<Multimedia> multimediaRepository,
            IRepository<Booklet> bookletRepository)
        {
            _context = context;
            _bus = bus;
            _bookRepository = bookRepository;
            _magazinRepository = magazinRepository;
            _articleRepository = articleRepository;
            _thesisRepository = thesisRepository;
            _multimediaRepository = multimediaRepository;
            _bookletRepository = bookletRepository;

        }


        public void Handle(CreateBookCommand command)
        {
            command.Id = Guid.NewGuid();
            command.CreatedDateTime = DateTime.Now;
            command.LastSavedDateTime = DateTime.Now;

            var book =
                new Book(command.Id, command.OwnerId, command.CreatedDateTime, command.LastSavedDateTime,
                         command.ProposerName, command.Title, command.Keyword, Status.Verrifing, command.UserType,
                         null, command.PublishingYear, command.OriginalFile, command.FileType,
                         command.PublisherName, command.AuthersName, command.TranslatorsName, command.SoftwareNeededToOpenFile)
                {
                    Privileges = new List<Privilege>(),
                    LeasonGradeList = new List<LeasonGrade>()
                };

            foreach (var item in command.Privileges)
            {
                AccessType y = item.AccessType;

                Privilege privilegeItem = new Privilege(item.Id , y);
                  
                book.Privileges.Add(privilegeItem);
            }

            foreach (var item in command.LeasonGradeList)
            {

                LeasonGrade leasonGradeItem = new LeasonGrade(item.Id, item.Grade, item.LessonName);

                book.LeasonGradeList.Add(leasonGradeItem);
            }

            _bookRepository.Add(book);
            _context.SaveChanges();
        }
    }
}
