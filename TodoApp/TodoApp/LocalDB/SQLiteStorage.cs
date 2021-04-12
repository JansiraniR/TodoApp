using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SQLite;

namespace TodoApp.LocalDB
{
    public class SQLiteStorage<T> : ISQLiteStorage<T> where T : class, new()
    {
        /// <summary>
        /// Class SQLiteRepository which implements interface ISQLiteRepository
        /// </summary>
        private SQLiteAsyncConnection _database;
        /// <summary>
        /// Class SQLiteRepository which implements interface ISQLiteRepository
        /// </summary>
        private string _databasePath;
        /// <summary>
        /// Class SQLiteRepository which implements interface ISQLiteRepository
        /// </summary>


        public SQLiteStorage(string SqliteDBName, string basePath = null)
        {
            if (string.IsNullOrWhiteSpace(basePath))
            {

                var fileSystemService = new SQLiteFileSystem();
                basePath = fileSystemService.DataFolderPath;
            }
            try
            {
                _databasePath = basePath; // Path.Combine(basePath, SqliteDBName);

                _database = new SQLiteAsyncConnection(_databasePath);

                _database.CreateTableAsync<T>();

            }
            catch (Exception ex)
            {

                //("Unable to create database at {basePath}. Reason:  {ex.Message}");
            }


        }
        /// <summary>
        /// Create Asyn Table.
        /// </summary>
        //public AsyncTableQuery<T> AsQueryable() =>
        //_database.Table<T>();
        /// <summary>
        /// Determines List of data in the table.
        /// </summary>
        public async Task<List<T>> Get()
        {
            return await _database.Table<T>().ToListAsync();
        }
        /// <summary>
        /// Determines specific T Type of data in the table with Expression.
        /// </summary>
        /// <param name="predicate">The Expression.</param>
        /// <param name="orderBy">The Expression.</param>
        public async Task<List<T>> Get<TValue>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, TValue>> orderBy = null)
        {
            var query = _database.Table<T>();

            if (predicate != null)
                query = query.Where(predicate);

            if (orderBy != null)
                query = query.OrderBy<TValue>(orderBy);

            return await query.ToListAsync();
        }
        /// <summary>
        /// Determines specific T Type of data in the table.
        /// </summary>
        /// <param name="id">The Id of the table.</param>
        public async Task<T> Get(int id) =>
             await _database.FindAsync<T>(id);
        /// <summary>
        /// Determines specific T Type of data in the table with Expression.
        /// </summary>
        /// <param name="predicate">The Expression.</param>
        public async Task<T> Get(Expression<Func<T, bool>> predicate) =>
            await _database.FindAsync<T>(predicate);
        /// <summary>
        /// Insert data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        public async Task<int> Insert(T entity) =>
             await _database.InsertAsync(entity);
        /// <summary>
        /// Update data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        public async Task<int> Update(T entity) =>
             await _database.UpdateAsync(entity);
        /// <summary>
        /// Delete data in Table.
        /// </summary>
        /// <param name="entity">The T type.</param>
        public async Task<int> Delete(T entity) =>
            await _database.DeleteAsync(entity);
        public async Task<T> Clear()
        {
            await _database.DropTableAsync<T>();
            await _database.CreateTableAsync<T>();
            return null;
        }

    }
}
