using MiniBankingCLI.Domain.Enums;

namespace MiniBankingCLI.Domain.Entities
{
    public class Transaction
    {
        public Transaction(decimal amount, TransactionType type, string? description = null)
        { 
        
            this.Amount = amount;
            this.Description = description;
            this.Type = type;
        }
      public Guid Id { get; private set; } = Guid.NewGuid();
      public TransactionType Type { get; private set; }  
      public decimal Amount { get; private set; }
      public string? Description { get; private set; }
      public DateTime CreatedDate { get; private set; } = DateTime.Now;
    }
}