using CashFlow.Application.UseCases.User;
using CashFlow.Exception;
using CommunTestUtilities.Request;
using FluentAssertions;

namespace Validators.Tests.Users.Register;

    public class RegisterUserValidatorTest
    {
        [Fact]

        public void Sucess()
        {
            //Arrange
            var validator = new userValidator();
            var request = RequestUserJsonBuilder.Build().Generate();
            //Act
            var result = validator.Validate(request);
            //Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("       ")]
        [InlineData(null)]
    public void Name_Is_Empty(string name)
    {
        //Arrange
        var validator = new userValidator();
        var request = RequestUserJsonBuilder.Build().Generate();
        request.Name = name;
        //Act
        var result = validator.Validate(request);
        //Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_REQUIRED)) ;
    }
    [Theory]
    [InlineData("")]
    [InlineData("        ")]
    [InlineData(null)]
    public void Email_Is_Empty(string email)
    {
        var validator = new userValidator();
        var request = RequestUserJsonBuilder.Build().Generate();
        request.Email = email;
        
        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_REQUIRED));
    }
    [Fact]
    public void Error_Password_Empty()
    {
        var validator = new userValidator();
        var request = RequestUserJsonBuilder.Build().Generate();
        request.Password = string.Empty;

        var result = validator.Validate(request);
        Console.WriteLine(result.Errors);
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Contains(ResourceErrorMessages.INVALID_PASSWORD));
    }
}

