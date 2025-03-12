using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Security.Tokens
{
    public interface IAcessTokenGenerator
    {
        string Generate (User user);
    }
}
