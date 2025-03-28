using CashFlow.Application.UseCases.User.Register;
using CashFlow.Domain.Repositories.User;
using CommunTestUtilities.Mapper;
using CommunTestUtilities.Repositories;
using CommunTestUtilities.Request;
using DocumentFormat.OpenXml.Spreadsheet;
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
    private RegisterUserUseCase CreateUseCase()
    {
        var mapper = MapperBuilder.Build();
        var unitOfWork = UnitOfWorkBuilder.Build();
        var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
        var readRepository = new UserReadOnlyRepositoryBuilder();

        return new RegisterUserUseCase(mapper, null, readRepository.Build(), writeRepository, null, unitOfWork);
    }

  
}

