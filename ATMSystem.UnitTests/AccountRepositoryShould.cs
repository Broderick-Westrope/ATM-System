using AutoFixture.Xunit2;
using FluentAssertions;

namespace ATMSystem.UnitTests;

public class AccountRepositoryShould
{
    [Theory]
    [AutoData]
    public void GetAllAccounts(List<Account> accounts)
    {
        // Arrange
        var repository = new AccountRepository(accounts);

        // Act
        var result = repository.GetAll();

        // Assert
        result.Should().BeEquivalentTo(accounts);
    }

    [Theory]
    [AutoData]
    public void GetAccount(List<Account> accounts)
    {
        // Arrange
        var targetAccount = accounts[0];
        var repository = new AccountRepository(accounts);

        // Act
        var result = repository.Get(targetAccount.CardNumber);

        // Assert
        result.Should().NotBeNull();
        result.Should().Be(targetAccount);
    }

    [Theory]
    [AutoData]
    public void AddAccount(Account account)
    {
        // Arrange
        var accountList = new List<Account>();
        var repository = new AccountRepository(accountList);

        // Act
        repository.Add(account);

        // Assert
        accountList.Should().HaveCount(1);
        accountList.First().Should().Be(account);
    }

    [Theory]
    [AutoData]
    public void DeleteAccount(List<Account> accounts)
    {
        // Arrange
        var account = accounts[0];
        var repository = new AccountRepository(accounts);

        // Act
        repository.Delete(account.CardNumber);

        // Assert
        accounts.Should().NotContain(account);
    }
}