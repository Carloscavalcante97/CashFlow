using CashFlow.Application.UseCases.Login;
using CashFlow.Domain.Entities;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
using CommunTestUtilities.Cryptography;
using CommunTestUtilities.Entities;
using CommunTestUtilities.Repositories;
using CommunTestUtilities.Request;
using CommunTestUtilities.Token;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.Test.Login
{
    public class DoLoginTest
    {
        
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();

            var request = RequestLoginJsonBuilder.Build();
            request.Email = user.Email;

            var useCase = CreateUseCase(user, request.Password);
            
            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(user.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();

        }

        [Fact]
        public async Task Error_User_Not_Found()
        {
            var user = UserBuilder.Build();

            var request = RequestLoginJsonBuilder.Build();

            var useCase = CreateUseCase(user);
            
            var act = async () => await useCase.Execute(request);

            var result = await act.Should().ThrowAsync<InvalidLoginException>();
            result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.PASSWORD_OR_EMAIL_INVALID));
        }
        [Fact]
        public async Task Error_Password_Invalid()
        {
            var user = UserBuilder.Build();

            var request = RequestLoginJsonBuilder.Build();

            request.Email = user.Email;

            request.Password = "123456";

            var useCase = CreateUseCase(user);

            var act = async () => await useCase.Execute(request);

            var result = await act.Should().ThrowAsync<InvalidLoginException>();

            result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.PASSWORD_OR_EMAIL_INVALID));
        }

        private DoLoginUseCase CreateUseCase(User user, string? password = null)
        {
            var passwordEncripter = new PasswordEncripterBuilder().Verify(password).Build();
            var tokenGenerator = JwtTokenGeneratorBuild.Build();
            var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

            return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);
        }
    }
}
