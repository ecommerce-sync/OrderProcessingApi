using Microsoft.EntityFrameworkCore.Storage;
using OrderProcessingApi.Data.Interfaces;

namespace OrderProcessingApi.Data;

public class TransactionManager : ITransactionManager
{
    private readonly IRepository _repository;

    public TransactionManager(IRepository repository)
    {
        _repository = repository;
    }

    public IDbContextTransaction GetTransaction()
    {
        return _repository.GetCurrentTransaction() == null ? _repository.CreateTransaction() : new FakeTransaction();
    }
}