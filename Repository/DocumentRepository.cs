using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DocumentRepository : RepositoryBase<Document>, IDocumentRepository
    {
        public DocumentRepository(RepositoryContext repositoryContext)
            : base(repositoryContext) { }

        public async Task<Document> GetDocumentByIdAsync(Guid documentId)
        {
            return await GetByIdAsync(documentId);
        }
    }
    
}
