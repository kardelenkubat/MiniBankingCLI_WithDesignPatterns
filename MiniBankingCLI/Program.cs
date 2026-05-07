using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Decorators;
using MiniBankingCLI.Domain.Enums;
using MiniBankingCLI.Patterns.Factory;
using MiniBankingCLI.Repository;
using MiniBankingCLI.Services;

// 1. Repository
var repository = new InMemoryAccountRepository();

// 2. Decorator zinciri
ITransactionService service = new TransactionService();
service = new CommissionDecorator(service, 0.01m);
service = new LoggingDecorator(service);
service = new ValidationDecorator(service);

// 3. Test hesapları oluştur
var account1 = AccountFactory.Create("Kardelen", AccountType.Checking);
var account2 = AccountFactory.Create("Onur", AccountType.Savings);
repository.Add(account1);
repository.Add(account2);

// 4. İşlemler
service.Deposit(account1, 1000);
service.Withdraw(account1, 200);
service.Transfer(account1, account2, 300);

// 5. Geçmişi göster
foreach (var t in service.GetHistory(account1))
    Console.WriteLine($"{t.CreatedDate} | {t.Type} | {t.Amount}");
