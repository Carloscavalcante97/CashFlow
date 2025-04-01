using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunTestUtilities.Token
{
    public class JwtTokenGeneratorBuild
    {
        public static IAcessTokenGenerator Build()
        {
            var mock = new Mock<IAcessTokenGenerator>();
            mock.Setup(config => config.Generate(It.IsAny<User>())).Returns("Token");
            return mock.Object;
        }

    }
}
