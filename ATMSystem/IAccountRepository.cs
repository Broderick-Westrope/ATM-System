using System.Linq.Expressions;

namespace ATMSystem;

public interface IAccountRepository
{
    List<Account> GetAll();
    Account? Get(int cardNumber);
    void Add(Account account);
    void Delete(Account account);
    Account? Find(Predicate<Account> predicate);
}