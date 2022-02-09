using Microsoft.EntityFrameworkCore.Storage;

namespace OrderProcessingApi.Data.Interfaces;

public interface ITransactionManager
{
    IDbContextTransaction GetTransaction();
}