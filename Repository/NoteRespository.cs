using Domain.Models;
using Repository.Context;
using Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class NoteRespository : RepositoryBase<Note>, INoteRepository
    {
        public NoteRespository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
                
        }
    }
}
