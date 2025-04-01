using CashFlow.Domain.Security.Cryptography;
using Moq;

namespace CommunTestUtilities.Cryptography
{
    public class PasswordEncripterBuilder
    {

        private readonly Mock<IPasswordEncripter> _mock;

        public PasswordEncripterBuilder()
        {
            _mock = new Mock<IPasswordEncripter>();
            _mock.Setup(config => config.Encript(It.IsAny<string>())).Returns("!aagfasdgsa%");

        }
        public PasswordEncripterBuilder Verify(string? password)
        {
            if (string.IsNullOrEmpty(password) == false)
            {
                _mock.Setup(config => config.verify(password, It.IsAny<string>())).Returns(true);
            }
            return this;
        }
        public IPasswordEncripter Build() => _mock.Object;

    }
}
