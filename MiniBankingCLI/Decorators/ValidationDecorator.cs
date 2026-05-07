using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Entities;

namespace MiniBankingCLI.Decorators
{
    public class ValidationDecorator : ITransactionService
    {
        private readonly ITransactionService _inner;

        public ValidationDecorator(ITransactionService inner)
        {
            _inner = inner;
        }

        public void Deposit(IAccount account, decimal amount)
        {
            if (amount <=0)
            {
                throw new ArgumentException("Amount must be bigger than 0.");

            }
            _inner.Deposit(account, amount);
        }

        public IReadOnlyList<Transaction> GetHistory(IAccount account)
        {
            return _inner.GetHistory(account);
        }

        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
            if (from.Id == to.Id)
                throw new ArgumentException("You can't transfer to yourself.");

            _inner.Transfer(from, to, amount);
        }

        public void Withdraw(IAccount account, decimal amount)
        {
            if (amount > account.Balance)
            {
                throw new ArgumentException("Insufficient funds");

            }
            _inner.Withdraw(account, amount);
        }

       
    }
}