using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Domain.Security.Tokens;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Login
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _userRepository;
        private readonly IPasswordEncripter _passwordEncripter;
        private readonly IAcessTokenGenerator _accessTokenGenerator;
        public DoLoginUseCase(
            IUserReadOnlyRepository userRepository,
            IPasswordEncripter passwordEncripter,
            IAcessTokenGenerator accessTokenGenerator
            )
        {
            _userRepository = userRepository;
            _passwordEncripter = passwordEncripter;
            _accessTokenGenerator = accessTokenGenerator;
        }
        public async Task<ResponseRegisteredUserJson> Execute(RequestLoginJson request)
        {
            var user = await _userRepository.GetUserByEmail(request.Email);
            if(user is null)
            {
                throw new InvalidLoginException();
            }
            var passwordMatch = _passwordEncripter.verify(request.Password, user.Password);

            if(passwordMatch is false)
            {
                throw new InvalidLoginException();
            }
            
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
