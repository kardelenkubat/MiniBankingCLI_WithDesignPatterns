using MiniBankingCLI.Abstractions;
using MiniBankingCLI.Domain.Entities;
using MiniBankingCLI.Domain.Enums;
using System.Runtime.InteropServices;

namespace MiniBankingCLI.Patterns.Factory
{
    public class AccountFactory
    {
        public static IAccount  Create(string ownerName, AccountType type)
        {
            return type switch
            {
                AccountType.Checking => new Account(ownerName, type),
                AccountType.Savings => new Account(ownerName, type),
                AccountType.Credit => new Account(ownerName, type),
                _ => throw new ArgumentException("Geçersiz hesap türü.")
            };
        }
    }
}