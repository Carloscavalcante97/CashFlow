using CashFlow.Application.UseCases.User.Register;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using CommunTestUtilities.Cryptography;
using CommunTestUtilities.Mapper;
using CommunTestUtilities.Repositories;
using CommunTestUtilities.Request;
using CommunTestUtilities.Token;
using FluentAssertions;

namespace UseCases.Test.Users.Register;
public class RegisterUserUseCaseTest
{
    [Fact]
    public async Task Succes()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var useCase = CreateUseCase();

        var result = await useCase.Execute(request);

        result.Should().NotBeNull();
        result.Name.Should().Be(request.Name);
        result.Token.Should().NotBeNullOrEmpty();
    }
    private RegisterUserUseCase CreateUseCase(string? email = null)
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder();
        var passwordEncripter = new PasswordEncripterBuilder().Build();
        var acessTokenGenerator = JwtTokenGeneratorBuild.Build();

        if(string.IsNullOrEmpty(email) == false)
        {
            readRepository.ExistActiveUserWithEmail(email);
        }

        return new RegisterUserUseCase(mapper, passwordEncripter, readRepository.Build(), writeRepository, acessTokenGenerator, unitOfWork);
    }

    [Fact]
    public async Task Name_Is_Empty()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        
        var useCase = CreateUseCase();
        
        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.NAME_REQUIRED));
    }

    [Fact]
    public async Task Email_Exist()
    {
        var request = RequestRegisterUserJsonBuilder.Build();

        var useCase = CreateUseCase(request.Email);

        var act = async () => await useCase.Execute(request);

        var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

        result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
    }
}

