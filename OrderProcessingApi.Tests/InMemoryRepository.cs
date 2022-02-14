using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;
using OrderProcessingApi.Data;
using OrderProcessingApi.Data.Interfaces;

namespace OrderProcessingApi.Tests
{
    public class InMemoryRepository : IRepository
    {
        private readonly IList<object> _entities = new List<object>();

        public IDbContextTransaction GetCurrentTransaction()
        {
            return new FakeTransaction();
        }

        public IDbContextTransaction CreateTransaction()
        {
            return new FakeTransaction();
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
        {
            return _entities.OfType<TEntity>().AsQueryable();
        }

        public void ExecuteSql(string sql, params SqlParameter[] parameters)
        {
        }

        public IEnumerable<TEntity> GetViaSql<TEntity>(string sql) where TEntity : class
        {
            return new List<TEntity>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : class
        {
            _entities.Add(entity);
        }

        public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void Update<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public void Delete<TEntity>(TEntity entity) where TEntity : class
        {
            _entities.Remove(entity);
        }

        public void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
        {
            foreach (var entity in entities)
            {
                _entities.Remove(entity);
            }
        }

        public void Attach<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public void SetStateToModified<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public void SetStateToUnchanged<TEntity>(TEntity entity) where TEntity : class
        {
        }

        public void Commit()
        {
        }

        public void SetTimeout(int? seconds)
        {
        }

        public int? GetTimeout()
        {
            return null;
        }

        public void SetTimeout(int seconds)
        {
        }

        public void EnableChangeTracking()
        {
        }

        public void DisableChangeTracking()
        {
        }

        public string GetDatabaseName()
        {
            return "InMemoryDatabase";
        }
    }
}