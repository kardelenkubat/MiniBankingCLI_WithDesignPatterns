using MiniBankingCLI.Domain.Entities;
using MiniBankingCLI.Domain.Enums;

namespace MiniBankingCLI.Abstractions
{
    public interface IAccount
    {
        Guid Id { get; }
        string OwnerName { get; }
        AccountType Type { get; }
        decimal Balance { get; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);
        IReadOnlyList<Transaction> GetHistory();
    }
}