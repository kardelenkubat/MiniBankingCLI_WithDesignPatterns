using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Entities;

namespace MiniBankingCLI.Decorators
{
    public class LoggingDecorator : ITransactionService
    {
        private readonly ITransactionService _inner;

        public LoggingDecorator(ITransactionService inner)
        {
            _inner = inner;
        }

        public void Deposit(IAccount account, decimal amount)
        {
            try
            {
                Console.WriteLine("Deposit işlemi başladı Account Id:" + account.Id);
                _inner.Deposit(account, amount);
                Console.WriteLine("Deposit tamamlandı."); 
            }
            catch(Exception ex) {
            
                Console.WriteLine($"Error {ex.Message}");
                throw;


            }
          
        }

        public IReadOnlyList<Transaction> GetHistory(IAccount account)
        {
            return _inner.GetHistory(account);
        }

        public void Transfer(IAccount from, IAccount to, decimal amount)
        {
            try
            {
                Console.WriteLine($"Transfer başladı. From: {from.OwnerName} To: {to.OwnerName} Amount: {amount}");
                _inner.Transfer(from, to, amount);
                Console.WriteLine("Transfer tamamlandı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }
        public void Withdraw(IAccount account, decimal amount)
        {
            try
            {
                Console.WriteLine($"Withdraw başladı. Account: {account.OwnerName} Amount: {amount}");
                _inner.Withdraw(account, amount);
                Console.WriteLine("Withdraw tamamlandı.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
                throw;
            }
        }


    }
}