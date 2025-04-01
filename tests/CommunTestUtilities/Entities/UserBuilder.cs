using Bogus;
using CashFlow.Domain.Entities;
using CommunTestUtilities.Cryptography;

namespace CommunTestUtilities.Entities
{
    public class UserBuilder
    {
        public static User Build()
        {
            var passwordEncripter = new PasswordEncripterBuilder().Build();

            var user = new Faker<User>()
                .RuleFor(user => user.Id, _ => 1)
                .RuleFor(user => user.Name, faker => faker.Person.FirstName)
                .RuleFor(user => user.Email, (faker, u) => faker.Internet.Email(u.Name))
                .RuleFor(user => user.Password, (_, u) => passwordEncripter.Encript(u.Password))
                .RuleFor(user => user.UserIdentifier, _ => Guid.NewGuid());
                

            return user;
        }
    }
}
