using Bogus;
using CashFlow.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunTestUtilities.Request
{
    public class RequestRegisterUserJsonBuilder
    {
        public static RequestRegisterUserJson Build()
        {
            return new Faker<RequestRegisterUserJson>()
                .RuleFor(user => user.Name, faker => faker.Person.FirstName)
                .RuleFor(user => user.Email, (faker,user) => faker.Internet.Email(user.Name))
                .RuleFor(user => user.Password, faker => faker.Internet.Password(prefix: "!Aa1"));
            

        }
    }
}
