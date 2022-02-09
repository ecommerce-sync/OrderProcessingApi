using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage;

namespace OrderProcessingApi.Data.Interfaces;

public interface IRepository
{
    IDbContextTransaction GetCurrentTransaction();
    IDbContextTransaction CreateTransaction();
    IQueryable<TEntity> GetAll<TEntity>() where TEntity : class;
    void ExecuteSql(string sql, params SqlParameter[] parameters);
    void Add<TEntity>(TEntity entity) where TEntity : class;
    void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    void Update<TEntity>(TEntity entity) where TEntity : class;
    void Delete<TEntity>(TEntity entity) where TEntity : class;
    void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class;
    void Attach<TEntity>(TEntity entity) where TEntity : class;
    void SetStateToModified<TEntity>(TEntity entity) where TEntity : class;
    void SetStateToUnchanged<TEntity>(TEntity entity) where TEntity : class;
    void Commit();
    void SetTimeout(int? seconds);
    int? GetTimeout();
    void EnableChangeTracking();
    void DisableChangeTracking();
    string GetDatabaseName();
}