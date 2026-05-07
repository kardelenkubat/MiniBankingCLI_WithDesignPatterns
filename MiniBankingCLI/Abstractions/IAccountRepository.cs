namespace MiniBankingCLI.Abstractions
{
    public interface IAccountRepository
    {
        void Add(IAccount account);
        IAccount? GetById(Guid id);
        IEnumerable<IAccount> GetAll();
        void Delete(Guid id);
        void Update(IAccount account);
    }
}