﻿namespace Tokenization.Core.API.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(object id);

        Task<T> InsertAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(object id);
    }
}
