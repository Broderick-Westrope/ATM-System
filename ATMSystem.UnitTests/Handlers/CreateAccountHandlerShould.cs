using ATMSystem.Handlers.CreateAccount;
using ATMSystem.Repositories;
using AutoFixture;
using FluentAssertions;
using Moq;

namespace ATMSystem.UnitTests.Handlers;

public class CreateAccountHandlerShould
{
    [Fact]
    public void CreateAccount()
    {
        // Arrange
        var command = new Fixture()
            .Build<CreateAccount>()
            .With(x => x.Pin, 1234)
            .Create();
        var mockRepository = new Mock<IAccountRepository>();
        var handler = new CreateAccountHandler(mockRepository.Object);

        // Act
        var result = handler.Handle(command);

        // Assert
        result.Name.Should().Be(command.Name);
        result.Pin.Should().Be(command.Pin);
    }

    [Fact]
    public void AddAccountToRepository()
    {
        // Arrange
        var command = new Fixture()
            .Build<CreateAccount>()
            .With(x => x.Pin, 1234)
            .Create();
        var mockRepository = new Mock<IAccountRepository>();
        var handler = new CreateAccountHandler(mockRepository.Object);

        // Act
        handler.Handle(command);

        // Assert
        mockRepository.Verify(x => x.Add(
            It.Is<Account>(y => y.Name == command.Name && y.Pin == command.Pin)
        ));
    }

    [Fact]
    public void VerifyPinIsTooLarge()
    {
        // Arrange
        var command = new Fixture()
            .Build<CreateAccount>()
            .With(x => x.Pin, 10000)
            .Create();
        var mockRepository = new Mock<IAccountRepository>();
        var handler = new CreateAccountHandler(mockRepository.Object);

        // Act
        Action act = () => handler.Handle(command);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Pin is incorrect.");
    }

    [Fact]
    public void VerifyPinIsTooSmall()
    {
        // Arrange
        var command = new Fixture()
            .Build<CreateAccount>()
            .With(x => x.Pin, 999)
            .Create();
        var mockRepository = new Mock<IAccountRepository>();
        var handler = new CreateAccountHandler(mockRepository.Object);

        // Act
        Action act = () => handler.Handle(command);

        // Assert
        act.Should()
            .Throw<ArgumentException>()
            .WithMessage("Pin is incorrect.");
    }
}