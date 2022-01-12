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
    public class IntegrationTest
    {
      protected readonly HttpClient TestClient;

      public IntegrationTest(){

        var appFactory = new WebApplicationFactory<Startup>();
        TestClient = appFactory.CreateClient();
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

            //Act
            var response = await TestClient.PostAsync(request.Url, content);

            //Asset
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}
