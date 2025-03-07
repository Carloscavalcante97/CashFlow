using AutoMapper;
using CashFlow.Communication.Reponses;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.User;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPasswordEncripter _encripter;
        private readonly IUserReadOnlyRepository     _userRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUserUseCase(
            IMapper mapper,
            IPasswordEncripter encripter,
            IUserReadOnlyRepository userRepository,
            IUnitOfWork unitOfWork,
            IUserWriteOnlyRepository userWriteOnlyRepository)
        {
            _mapper = mapper;
            _encripter = encripter;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userWriteOnlyRepository = userWriteOnlyRepository; 


        }
        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _encripter.Encript(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();
            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
            };
        }
        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new userValidator().Validate(request);

            var emailExist= await _userRepository.ExistActiveUserWithEmail(request.Email);
            if (emailExist)
            {
                result
                    .Errors
                    .Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREADY_REGISTERED));
            }
            if (result.IsValid is false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
