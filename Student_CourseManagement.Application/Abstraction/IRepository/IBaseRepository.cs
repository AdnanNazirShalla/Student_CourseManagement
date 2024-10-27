using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Student_CourseManagement.Application.Abstraction.IRepository
{
    public interface IBaseRepository
    {
        Task<int> AddAsync<T>(T entity) where T : class ;

        Task<int> AddRangeAsync<T>(IEnumerable<T> entities) where T : class ;

        Task<IEnumerable<T>> GetAllAsync<T>() where T : class ;

        Task<int> UpdateAsync<T>(T entity) where T : class;

        Task<int> UpdateRangeAsync<T>(IEnumerable<T> entity) where T : class ;

        Task<int> DeleteAsync<T>(T entity) where T : class ;

        Task<int> DeleteRangeAsync<T>(IEnumerable<T> entity) where T : class;

        Task<IQueryable<T>> FindBy<T>(Expression<Func<T, bool>> expression) where T : class;

        Task<T> FirstOrDefault<T>(Expression<Func<T, bool>> expression) where T : class;

        Task<T> GetById<T>(Guid id) where T : class ;

        Task<bool> IsExists<T>(Expression<Func<T, bool>> expression) where T : class;



        #region Dapper Methods

        Task<int> ExecuteAsync(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);


        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null, CommandType commandType = CommandType.Text, IDbTransaction? transaction = null, CancellationToken cancellationToken = default);



        #endregion

    }
}
