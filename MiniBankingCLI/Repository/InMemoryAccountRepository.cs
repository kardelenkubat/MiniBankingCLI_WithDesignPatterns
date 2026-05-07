using MiniBankingCLI.Abstractions;

namespace MiniBankingCLI.Repository
{
    public class InMemoryAccountRepository : IAccountRepository
    {
        private readonly List<IAccount> _accounts = new List<IAccount>();

        public void Add(IAccount account)
        {
           _accounts.Add(account);

        }

        public void Delete(Guid id)
        {
            var account = GetById(id);
            if (account != null)
            {
                _accounts.Remove(account);
            }
        }

        public IEnumerable<IAccount> GetAll()
        {
            return _accounts;
        }

        public IAccount? GetById(Guid id)
        {
            var account = _accounts.FirstOrDefault(x => x.Id == id);
            return account;
        }

        public void Update(IAccount account)
        {
            var existing = GetById(account.Id);
            if (existing == null)
                throw new InvalidOperationException("Account not found.");
            _accounts.Remove(existing);
            _accounts.Add(account);

        }
    }
}