using AutoMapper;
using TransactionAPI.Commands;
using TransactionAPI.Database.Entities;
using TransactionAPI.Database.Repositories;
using TransactionAPI.Models;

namespace TransactionAPI.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;
        private readonly IMapper _mapper;

        public TransactionsService(ITransactionsRepository transactionsRepository, IMapper mapper)
        {
            _transactionsRepository = transactionsRepository;
            _mapper = mapper;
        }
        public async Task<Models.Transaction> CreateTransaction(CreateTransactionCommand command)
        {
            var entity = _mapper.Map<TransactionEntity>(command);

            var existingTransaction = await _transactionsRepository.Get(command.TransactionId);
            if (existingTransaction != null)
            {
                return null;
            }
            var result = _transactionsRepository.Create(entity);

            return _mapper.Map<Models.Transaction>(result);
        }

        public async Task<bool> DeleteTransaction(string transactionId)
        {
            return await _transactionsRepository.Delete(transactionId);
        }

        public async Task<Models.Transaction> GetTransaction(string transactionId)
        {
            var transactionEntity = await _transactionsRepository.Get(transactionId);

            if (transactionEntity == null)
            {
                return null;
            }

            return _mapper.Map<Models.Transaction>(transactionEntity);
        }

         public async Task<PagedSortedList<Models.Transaction>> GetTransactions(int page = 1, int pageSize = 10, string sortBy = null, SortOrder sortOrder = SortOrder.Asc)
        {
            var result = await _transactionsRepository.List(page, pageSize, sortBy, sortOrder);

            return _mapper.Map<PagedSortedList<Models.Transaction>>(result);
        }
    }
    
}