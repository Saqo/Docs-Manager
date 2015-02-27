using System;
using System.Collections.Generic;
using Core.Models;

namespace Core.Repositories
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        IEnumerable<Document> GetAllByUserId(Guid Id);
    }
}
