
using Bogus;
using CashFlow.Communication.Request;

namespace CommunTestUtilities.Request;

public class RequestRegisterExpenseJsonBuilder
{
    public static RequestRegisterExpenseJson Build()
    {

        /* 
         Forma mais extensa.
         var faker = new Faker();
         var request = new RequestRegisterExpenseJson
        {
            Title = faker.Commerce.Product(),
            Date = faker.Date.Past(),
            Description = faker.Lorem.Sentence(),
            Amount = faker.Finance.Amount(),
            PaymentType = faker.PickRandom<CashFlow.Communication.Enum.PaymentType>()
        }; */
        return new Faker<RequestRegisterExpenseJson>()
            .RuleFor(rF => rF.Title, faker => faker.Commerce.ProductName())
            .RuleFor(rF => rF.Date, faker => faker.Date.Past())
            .RuleFor(rF => rF.Description, faker => faker.Commerce.ProductDescription())
            .RuleFor(rF => rF.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(rF => rF.PaymentType, faker => faker.PickRandom<CashFlow.Communication.Enum.PaymentType>());
        
    }
}
