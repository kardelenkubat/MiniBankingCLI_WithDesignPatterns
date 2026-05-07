
using MiniBankingCLI.Domain.Entities;

namespace MiniBankingCLI.Abstractions
{
    public interface ITransactionService
    {
       void Deposit(IAccount account,decimal amount);
        void Withdraw(IAccount account,decimal amount);
        void Transfer(IAccount from, IAccount to,decimal amount);
        IReadOnlyList<Transaction> GetHistory(IAccount account);
    }
}