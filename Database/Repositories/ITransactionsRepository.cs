using TransactionAPI.Database.Entities;
using TransactionAPI.Models;

namespace TransactionAPI.Database.Repositories
{
     public interface ITransactionsRepository
    {
        Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        
        Task<TransactionEntity> Create(TransactionEntity transaction);

        Task<TransactionEntity> Get(string transactionId);

        Task<bool> Delete(string transactionId);
    }
}