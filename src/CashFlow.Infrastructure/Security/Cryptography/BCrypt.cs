using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
namespace CashFlow.Infrastructure.Security.Cryptography
{
    class BCrypt : IPasswordEncripter
    {
        public string Encript(string password)
        {
            string passwordHash = BC.HashPassword(password);
            return passwordHash;
        }
        public bool verify(string password, string passwordHash) => BC.Verify(password, passwordHash);

    }
}
