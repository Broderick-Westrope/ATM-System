namespace ATMSystem;

public interface IAccountRepository
{
    List<Account> GetAll();
    Account Get(Guid id);
    void Add(Account account);
    void Delete(Guid id);
}