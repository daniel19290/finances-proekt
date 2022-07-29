using TransactionAPI.Commands;
using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public interface ITransactionsService
    {
        Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc);
        Task<Models.Transaction> GetTransaction(string transactionId);
        Task<Models.Transaction> CreateTransaction(CreateTransactionCommand command);
        Task<bool> DeleteTransaction(string transactionId);
    }
}