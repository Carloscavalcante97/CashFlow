using CashFlow.Application.UseCases.CashFlow.Register;
using CashFlow.Communication.Request;
using CommunTestUtilities.Request;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register;

public class RegisterExpenseValidatortTests
{
    [Fact]
    public void Sucess()
    {
        //Arrange
        var validator = new RegisterExpenseValidator();
        var request = RequestRegisterExpenseJsonBuilder.Build();
        //Act
        var result = validator.Validate(request);
        //Assert
        result.IsValid.Should().BeTrue();
    }
}
