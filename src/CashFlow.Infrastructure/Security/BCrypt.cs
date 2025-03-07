using CashFlow.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;
namespace CashFlow.Infrastructure.Security
{
    class BCrypt : IPasswordEncripter
    {
        public string Encript(string password)
        {
            string passwordHash = BC.HashPassword(password);
            return passwordHash;
        }
    }
}
