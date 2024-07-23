﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T> > GetAll(Expression<Func<T, bool>> predicate = null);
    }
}
