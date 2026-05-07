using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Entities;


namespace MiniBankingCLI.Decorators
{
    public class CommissionDecorator : ITransactionService
    {
        private readonly ITransactionService _inner;
        private readonly decimal _commissionRate;

        public CommissionDecorator(ITransactionService inner, decimal commissionRate)
        {
            _inner = inner;
            _commissionRate = commissionRate;
        }

        public void Deposit(IAccount account, decimal amount)
        {
           
            _inner.Deposit(account, amount);
            account.Withdraw(CalculateCommission(amount));
        }

        public IReadOnlyList<Transaction> GetHistory(IAccount account)
        {
            return _inner.GetHistory(account);
        }

        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
      
            _inner.Transfer(from, to, amount);
            from.Withdraw(CalculateCommission(amount));
        }

        public void Withdraw(IAccount account, decimal amount)
        {
            _inner.Withdraw(account, amount);
            account.Withdraw(CalculateCommission(amount));
        }

        private decimal CalculateCommission(decimal amount)
        {
             var commission= amount *_commissionRate;
           
            return commission;
        }
     
    }
}