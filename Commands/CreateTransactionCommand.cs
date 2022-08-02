using TransactionAPI.Database.Entities;
using System.ComponentModel.DataAnnotations;

namespace TransactionAPI.Commands
{
    public class CreateTransactionCommand
    {
       [Required]
        public string TransactionId { get; set; }
       [Required]
        public string BeneficiaryName { get; set; }
        public string Date{ get; set; }

        public TransactionDirection? Direction { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public string Mcc { get; set; }

        public TransactionKind? Kind { get; set; }
    }
}
