using System.Collections.Generic;
using OrderProcessingApi.Data.Interfaces;

namespace OrderProcessingApi.Tests
{
    public abstract class InMemoryRepositoryTests
    {
        protected IRepository InMemoryRepository;

        protected void AddItemsToRepository<TItem>(IEnumerable<TItem> items) where TItem : class
        {
            foreach (var item in items)
            {
                AddItemToRepository(item);
            }
        }

        protected void AddItemToRepository<TItem>(TItem item) where TItem : class
        {
            InMemoryRepository.Add(item);
        }
    }
}