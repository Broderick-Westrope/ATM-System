namespace ATMSystem.Repositories;

public interface IAccountRepository
{
    List<Account> GetAll();
    Account? Get(int accountNumber);
    void Add(Account account);
    void Delete(Account account);
    Account? Find(Predicate<Account> predicate);
}