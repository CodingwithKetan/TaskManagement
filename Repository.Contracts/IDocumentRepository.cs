using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IDocumentRepository : IRepositoryBase<Document>
    {
        Task<Document> GetDocumentByIdAsync(Guid documentId);
    }
}
