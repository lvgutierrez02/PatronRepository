﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Practica.Core.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(Guid id);
        Task<bool> Add();
        Task<bool> Delete(Guid id);
        Task<bool> Upsert(T entity);
    }
}