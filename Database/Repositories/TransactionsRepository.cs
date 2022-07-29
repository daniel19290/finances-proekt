using Microsoft.EntityFrameworkCore;
using TransactionAPI.Database.Entities;
using TransactionAPI.Models;


namespace TransactionAPI.Database.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
       private readonly TransactionsDbContext _dbContext;

        public TransactionsRepository(TransactionsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TransactionEntity> Create(TransactionEntity transaction)
        {
            _dbContext.Transactions.Add(transaction);

            await _dbContext.SaveChangesAsync();

            return transaction;
        }

        public async Task<bool> Delete(string transactionId)
        {
            var transaction = await Get(transactionId);

            if (transaction == null)
            {
                return false;
            }

            _dbContext.Remove(transaction);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TransactionEntity> Get(string transactionId)
        {
            return await _dbContext.Transactions.FirstOrDefaultAsync(p => p.Id == transactionId);
        }

        public async Task<PagedSortedList<TransactionEntity>> List(int page = 1, int pageSize = 5, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var query = _dbContext.Transactions.AsQueryable();

            var totalCount = query.Count();

            var totalPages = (int)Math.Ceiling(totalCount * 1.0 / pageSize);

            if (!string.IsNullOrEmpty(sortBy))
            {
                switch (sortBy)
                {
                    case "id":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Id) : query.OrderByDescending(x => x.Id);
                        break;
                    case "description":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.Description) : query.OrderByDescending(x => x.Description);
                        break;
                    default:
                    case "BeneficiaryName":
                        query = sortOrder == SortOrder.Asc ? query.OrderBy(x => x.BeneficiaryName) : query.OrderByDescending(x => x.BeneficiaryName);
                        break;
                }
            } 
            else
            {
                query = query.OrderBy(p => p.BeneficiaryName);
            }

            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            var items = await query.ToListAsync();

            return new PagedSortedList<TransactionEntity>
            {
                Page = page,
                PageSize = pageSize,
                TotalCount = totalCount,
                TotalPages = totalPages,
                Items = items,
                SortBy = sortBy,
                SortOrder = sortOrder
            };
        }
    }
}
