using TransactionAPI.Database.Entities;

namespace TransactionAPI.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }

        public string BeneficiaryName { get; set; }
        public string Date{ get; set; }

        public TransactionDirection Direction { get; set; }

        public float Amount { get; set; }

        public string Description { get; set; }

        public string Currency { get; set; }

        public string Mcc { get; set; }

        public TransactionKind Kind { get; set; }
    }
}
