using CashFlow.Communication.Reponses;
using CommunTestUtilities.Request;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

namespace WebApi.Test.Users.Register
{
    public class RegisterUserTest : IClassFixture<CustomWebnApplicationFactory>
        
    {
        private const string METHOD = "api/User";
        private readonly HttpClient _httpClient;

        public RegisterUserTest(CustomWebnApplicationFactory webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Sucess()
        {

            var request = RequestRegisterUserJsonBuilder.Build();

            var result = await _httpClient.PostAsJsonAsync(METHOD, request);

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            var body = await result.Content.ReadAsStreamAsync();
           
            var response = await JsonDocument.ParseAsync(body);
           
            response.RootElement.GetProperty("name").GetString().Should().Be(request.Name);
            response.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
        }
    }
}
