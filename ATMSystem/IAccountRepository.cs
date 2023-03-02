using System.Linq.Expressions;

namespace ATMSystem;

public interface IAccountRepository
{
    List<Account> GetAll();
    Account? Get(int cardNumber);
    void Add(Account account);
    void Delete(int cardNumber);
    Account? Find(Predicate<Account> predicate);
}