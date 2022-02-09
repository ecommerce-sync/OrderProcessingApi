using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using OrderProcessingApi.Data.Interfaces;
using System.Data;

namespace OrderProcessingApi.Data;

public class Repository : IRepository
{
    private readonly Context _context;

    public Repository(Context context)
    {
        _context = context;
    }

    public IQueryable<TEntity> GetAll<TEntity>() where TEntity : class
    {
        return GetDbSet<TEntity>().Select(e => e);
    }

    public IDbContextTransaction GetCurrentTransaction()
    {
        return _context.Database.CurrentTransaction;
    }

    public IDbContextTransaction CreateTransaction()
    {
        return _context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
    }

    public void ExecuteSql(string sql, params SqlParameter[] parameters)
    {
        _context.Database.ExecuteSqlRaw(sql, parameters);
    }

    public void Add<TEntity>(TEntity entity) where TEntity : class
    {
        GetDbSet<TEntity>().Add(entity);
    }

    public void AddRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        GetDbSet<TEntity>().AddRange(entities);
    }

    public void Update<TEntity>(TEntity entity) where TEntity : class
    {
        GetDbSet<TEntity>().Update(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        GetDbSet<TEntity>().Remove(entity);
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void SetTimeout(int? seconds)
    {
        _context.Database.SetCommandTimeout(seconds);
    }

    public int? GetTimeout()
    {
        return _context.Database.GetCommandTimeout();
    }

    public void EnableChangeTracking()
    {
        _context.ChangeTracker.AutoDetectChangesEnabled = true;
    }

    public void DisableChangeTracking()
    {
        _context.ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public string GetDatabaseName()
    {
        return _context.Database.GetDbConnection().Database;
    }

    public void Attach<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Attach(entity).State = EntityState.Modified;
    }

    public void SetStateToModified<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Entry(entity).State = EntityState.Modified;
    }

    public void SetStateToUnchanged<TEntity>(TEntity entity) where TEntity : class
    {
        _context.Entry(entity).State = EntityState.Unchanged;
    }

    public void DeleteRange<TEntity>(IEnumerable<TEntity> entities) where TEntity : class
    {
        GetDbSet<TEntity>().RemoveRange(entities);
    }

    private DbSet<TEntity> GetDbSet<TEntity>() where TEntity : class
    {
        return _context.Set<TEntity>();
    }
}