using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Entities;

namespace MiniBankingCLI.Services
{
    public class TransactionService : ITransactionService
    {
        
        public void Deposit(IAccount account, decimal amount)
        {
           account.Deposit(amount);
        }

        public IReadOnlyList<Transaction> GetHistory(IAccount account)
        {
            return account.GetHistory();
        }

        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
            from.Withdraw(amount);
            to.Deposit(amount);
        }

        public void Withdraw(IAccount account, decimal amount)
        {
           account.Withdraw(amount);
        }
    }
}