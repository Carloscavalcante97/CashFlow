namespace CashFlow.Domain.Security.Cryptography
{
    public interface IPasswordEncripter
    {
        string Encript(string password);
        bool verify(string password, string passwordHash);
    }
}
