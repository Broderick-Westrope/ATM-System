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
            new(),
            new(),
            new()
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
        var accountList = new List<Account>
        {
            //? Is it better to add the items this way or add them using the repository method? Should the number of entries be randomised?
            new(),
            new(),
            new()
        };
        var repository = new AccountRepository(accountList);
        
        // Act
        var account = repository.Get();
        
        // Assert
        accountList[1].Should().Equals(account);
    }
    [Fact]
    public void AddAccount()
    {
        // Arrange
        var accountList = new List<Account>();
        var repository = new AccountRepository(accountList);
        var account = new Account();
        
        // Act
        repository.Add(account);
        
        // Assert
        accountList.Should().HaveCount(1);
    }
    
    [Fact]
    public void DeleteAccount()
    {

    }
}