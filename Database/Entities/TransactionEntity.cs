namespace TransactionAPI.Database.Entities
{
       public class TransactionEntity{
        public string Id { get; set; }

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