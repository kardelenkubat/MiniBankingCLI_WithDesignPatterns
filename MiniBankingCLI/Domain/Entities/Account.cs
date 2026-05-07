using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Enums;

namespace MiniBankingCLI.Domain.Entities
{ 
  
    public class Account : IAccount
    {
        public Account(string ownerName, AccountType type ) {
            this.OwnerName = ownerName;
            this.Type = type;
            Transactions = new List<Transaction>();
        }

        public Guid Id { get; private set; } = Guid.NewGuid();
        public string OwnerName { get; private set; }

        public AccountType Type { get; private set; }
        public decimal Balance { get; private set; }

        public List<Transaction> Transactions { get; private set; }


        public void Deposit(decimal amount)
        {
            Balance += amount;
            var transaction = new Transaction(amount, TransactionType.Deposit);
            Transactions.Add(transaction);
        }
        public void Withdraw(decimal amount)
        {
            if (amount > Balance) throw new InvalidOperationException("Insufficient Funds");
            Balance -= amount;
            var transaction = new Transaction(amount, TransactionType.Withdrawal);
            Transactions.Add(transaction);

        }
        public IReadOnlyList<Transaction> GetHistory()
        {
            return Transactions;
        }
    }


}