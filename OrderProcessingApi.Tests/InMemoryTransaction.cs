using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;

namespace OrderProcessingApi.Tests;

public class InMemoryTransaction : IDbContextTransaction
{
    public void Dispose()
    {
    }

    public void Commit()
    {
    }

    public void Rollback()
    {
    }

    public Task CommitAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RollbackAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public void CreateSavepoint(string name)
    {
        throw new NotImplementedException();
    }

    public Task CreateSavepointAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public void RollbackToSavepoint(string name)
    {
        throw new NotImplementedException();
    }

    public Task RollbackToSavepointAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public void ReleaseSavepoint(string name)
    {
        throw new NotImplementedException();
    }

    public Task ReleaseSavepointAsync(string name, CancellationToken cancellationToken = new CancellationToken())
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public Guid TransactionId => Guid.Empty;
    public bool SupportsSavepoints { get; }
}