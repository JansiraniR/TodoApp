using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TodoApp.LocalDB
{
    public interface ISQLiteStorage<T> where T : class, new()
    {
        /// <summary>
        /// Determines List of data in the table.
        /// </summary>
        Task<List<T>> Get();
        /// <summary>
        /// Determines specific T Type of data in the table.
        /// </summary>
        /// <param name="id">The Id of the table.</param>
        Task<T> Get(int id);
        /// <summary>
        /// Determines specific T Type of data in the table with Expression.
        /// </summary>
        /// <param name="predicate">The Expression.</param>
        /// <param name="orderBy">The Expression.</param>
        Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null);
        /// <summary>
        /// Determines specific T Type of data in the table with Expression.
        /// </summary>
        /// <param name="predicate">The Expression.</param>
        Task<T> Get(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// Create Asyn Table.
        /// </summary>
        //AsyncTableQuery<T> AsQueryable();
        /// <summary>
        /// Insert data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        Task<int> Insert(T entity);
        /// <summary>
        /// Update data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        Task<int> Update(T entity);
        /// <summary>
        /// Delete data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        Task<int> Delete(T entity);
        Task<T> Clear();
    }
}