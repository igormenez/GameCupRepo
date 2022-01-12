using GameCup.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Headers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Net.Http;
using System.Net;
using FluentAssertions;


namespace GameCup.test
{
    public class IntegrationTest: IClassFixture<WebApplicationFactory<Startup>>
    {
       private readonly WebApplicationFactory<Startup> _factory;

        public IntegrationTest(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task PostLisGamesRequest()
        {
            // Arrange
            var request = new{
              Url = "/v1",
              Body = Game.FakeData.Generate(8)
            };
            var content = new StringContent(request.Body.ToString());
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            var client = _factory.CreateClient();

            //Act
            var response = await client.PostAsync(request.Url, content);

            //Asset
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
