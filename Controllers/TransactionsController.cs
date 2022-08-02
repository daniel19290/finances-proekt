using System.Globalization;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using TransactionAPI.Commands;
using TransactionAPI.Models;
using TransactionAPI.Services;
using TransactionAPI;



namespace TransactionAPI.Controllers
{
    [Route("transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _transactionsService;
        private readonly ILogger<TransactionsController> _logger;

        public TransactionsController(ITransactionsService transactionsService, ILogger<TransactionsController> logger)
        {
            _transactionsService = transactionsService;
            _logger = logger;
        }

        [HttpGet]
       public async Task<IActionResult> GetTransactions([FromQuery] int? page, [FromQuery] int? pageSize, [FromQuery] string sortBy, [FromQuery] SortOrder sortOrder)
        {
            page = page ?? 1;
            pageSize = pageSize ?? 10;
            _logger.LogInformation("Returning {page}. page of transactions", page);
            var result = await _transactionsService.GetTransactions(page.Value, pageSize.Value, sortBy, sortOrder);
            return Ok(result);
        }

        [HttpGet("{transactionId}")]
        public async Task<IActionResult> GetTransaction([FromRoute] string transactionId)
        {
            var transaction = await _transactionsService.GetTransaction(transactionId);

            if (transaction == null)
            {
                return NotFound();
            }

            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionCommand command)
        {
            var result = await _transactionsService.CreateTransaction(command);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
           

        [HttpDelete("{transactionId}")]
        public async Task<IActionResult> DeleteTransaction([FromRoute] string transactionId)
        {
            var result = await _transactionsService.DeleteTransaction(transactionId);
            if (!result)
            {
                return NotFound();
            }
            return Ok();
        }
    }

 

    
   
}
