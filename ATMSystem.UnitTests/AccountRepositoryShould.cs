using ATMSystem;
using FluentAssertions;

namespace ATMSystem.UnitTests;

public class AccountRepositoryShould
{
    [Fact]
    public void GetAllAccounts()
    {
        // Arrange
        var accountList = new List<Account>
        {
            //? Is it better to add the items this way or add them using the repository method? Should the number of entries be randomised?
            new(111111, "Bob", 1111),
            new(222222, "Ben", 2222),
            new(333333, "Gary", 3333)
        };
        var repository = new AccountRepository(accountList);

        // Act
        var result = repository.GetAll();
        
        // Assert
        accountList.Should().Equal(result);
    }
    
    [Fact]
    public void GetAccount()
    {
        // Arrange
        var targetAccount = new Account(222222, "Ben", 2222);
        var accountList = new List<Account>
        {
            //? Is it better to add the items this way or add them using the repository method? Should the number of entries be randomised?
            new(111111, "Bob", 1111),
            targetAccount,
            new(333333, "Gary", 3333)
        };
        var repository = new AccountRepository(accountList);
        var expectedAccount = new Account(222222, "Ben", 2222);
        
        // Act
        var account = repository.Get(222222);
        
        // Assert
        //? Since the first check uses the objects equality, is this just checking they are both Accounts? Should we instead use the second check?
        account.Should().Be(expectedAccount);
        account.CompareCardNumber(222222).Should().BeTrue();
        account.Should().NotBe(null);
    }
    [Fact]
    public void AddAccount()
    {
        // Arrange
        var accountList = new List<Account>();
        var repository = new AccountRepository(accountList);
        var account = new Account(111111, "Bob", 1111);
        
        // Act
        repository.Add(account);
        
        // Assert
        accountList.Should().HaveCount(1);
    }
    
    [Fact]
    public void DeleteAccount()
    {
        // Arrange
        var accountList = new List<Account>
        {
            new(111111, "Bob", 1111)
        };
        var repository = new AccountRepository(accountList);
        
        // Act
        repository.Delete(111111);

        // Assert
        accountList.Should().BeEmpty();
    }
}