using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Tearc.Repository.Base;

namespace Tearc.Repository.Log
{
    public class LogRepository : IRepository
    {
        public IQueryable<TEntity> All<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void BeginAuditLog()
        {
            throw new NotImplementedException();
        }

        public ITransaction BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            throw new NotImplementedException();
        }

        public bool Contain<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<bool> ContainAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int Count<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> CountAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Create<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void CreateMany<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task CreateManyAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int Delete<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int DeleteById<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteByIdAsync<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public int DeleteMany<TEntity>(IEnumerable<object> ids) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteManyAsync<TEntity>(IEnumerable<object> ids) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public int ExecuteNonQuery(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public TResult ExecuteReader<TResult>(string query, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Filter<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity Find<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindAsync<TEntity>(Expression<Func<TEntity, bool>> predicate) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TEntity FindById<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindByIdAsync<TEntity>(object id) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public TContext GetDbContext<TContext>() where TContext : class
        {
            throw new NotImplementedException();
        }

        public string GetLastLog()
        {
            throw new NotImplementedException();
        }

        public int Update<TEntity>(object id, TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync<TEntity>(object id, TEntity entity) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public void UpdatRelationship<TEntity, TRelationship>(object entityId, Expression<Func<TRelationship, bool>> relationShipFilter, Func<TEntity, ICollection<TRelationship>> relationshipSelector)
            where TEntity : class
            where TRelationship : class
        {
            throw new NotImplementedException();
        }

        public Task UpdatRelationshipAsync<TEntity, TRelationship>(object entityId, Expression<Func<TRelationship, bool>> relationShipFilter, Func<TEntity, ICollection<TRelationship>> relationshipSelector)
            where TEntity : class
            where TRelationship : class
        {
            throw new NotImplementedException();
        }
    }
}
