using Student_CourseManagement.Application.Abstraction.IRepository;
using Student_CourseManagement.Persistance.DB;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace Student_CourseManagement.Persistance.Repository
{
    public class BaseRepository : IBaseRepository
    {
        private readonly AppDbContext dbContext;

        public BaseRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> AddAsync<T>(T entity) where T : class
        {
           await dbContext.Set<T>().AddAsync(entity);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> AddRangeAsync<T>(IEnumerable<T> entities) where T : class
        {
            await dbContext.Set<T>().AddRangeAsync(entities);
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var model=await dbContext.Set<T>().FindAsync(id);
           await Task.Run(()=> dbContext.Set<T>().Remove(model));
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteRangeAsync<T>(IEnumerable<T> entity) where T : class
        {
            await Task.Run(() => dbContext.Set<T>().RemoveRange(entity));
            return await dbContext.SaveChangesAsync();
        }

        public async Task<IQueryable<T>> FindBy<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await Task.Run(()=> dbContext.Set<T>().Where(expression));
        }

        public async Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> expression) where T : class
        {
            return await Task.Run(() => dbContext.Set<T>().Where(expression).FirstOrDefault());
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
           return await Task.Run(()=>dbContext.Set<T>());
        }

        public async Task<T> GetById<T>(Guid id) where T : class
        {
            return await dbContext.Set<T>().FindAsync(id);
        }

        public async Task<bool> IsExists<T>(Expression<Func<T, bool>> expression) where T : class
        {
           return await Task.Run(()=> dbContext.Set<T>().Any(expression));
        }

        public async Task<int> UpdateAsync<T>(T entity) where T : class
        {
            await Task.Run(()=> dbContext.Set<T>().Update(entity));
            return await dbContext.SaveChangesAsync();
        }

        public async Task<int> UpdateRangeAsync<T>(IEnumerable<T> entity) where T : class
        {
            await Task.Run(()=> dbContext.Set<T>().UpdateRange(entity));
            return await dbContext.SaveChangesAsync();
        }


        #region Dapper Methods

        /// <summary>
        ///  sql query including  parameter
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="param"></param>
        /// <param name="commandType">default is command text if stored procedure is need then pass commandType as store procedure</param>
        /// <param name="transaction">need to pass transaction object</param>
        /// <param name="cancellationToken">it is used for roll back</param>
        /// <returns></returns>

        public async Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await dbContext.ExecuteAsyncDapperExtension(sql, param!);
        }


        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null, CancellationToken cancellationToken = default)
        {
            return await dbContext.QueryAsyncDapperExtension<T>(sql, param!);
        }

        


        #endregion
    }

    
 #region Dapper Extensions

    public static class EFExtensions
    {
        public async static Task<IEnumerable<T>> QueryAsyncDapperExtension<T>(this DbContext context, string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            try
            {
                using var connection = new SqlConnection(context.Database.GetConnectionString());
                return await connection.QueryAsync<T>(sql, param, transaction, null, commandType);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }


        public async static Task<int> ExecuteAsyncDapperExtension(this DbContext context, string sql, object param = null, CommandType commandType = CommandType.Text, IDbTransaction transaction = null, CancellationToken cancellationToken = default)
        {
            try
            {
                using var connection = new SqlConnection(context.Database.GetConnectionString());
                return await connection.ExecuteAsync(sql, param, transaction, null, commandType);
            }
            catch (Exception exp)
            {
                throw new Exception(exp.Message, exp);
            }
        }

    }
}

#endregion

