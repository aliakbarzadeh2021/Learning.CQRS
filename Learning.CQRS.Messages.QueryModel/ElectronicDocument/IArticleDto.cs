
namespace Learning.CQRS.Messages.QueryModel.ElectronicDocument
{
    using System;
    using System.Collections.Generic;
    public interface IArticleDto
    {
        /// <inheritdoc />
        Guid Id { get; set; }
    }
}
