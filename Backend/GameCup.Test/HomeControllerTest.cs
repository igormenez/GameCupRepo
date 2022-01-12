using GameCup.Controllers;
using GameCup.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameCup.test
{
    public class HomeControllerTest
    {
        [Fact]
        public async Task ReturnWinerGameBehavor()
        {
            // Arrange
            var controller = new HomeController();
            var game_list = Game.FakeData.Generate(8);

            //Act
            var actionResult = await controller.PostAsync(game_list);

            //Asset
            var result = actionResult.Result as OkObjectResult;
            Assert.IsType<List<Game>>(result.Value);
        }

        [Fact]
        public async Task ReturnErrorWrongDataBehavor()
        {
            // Arrange
            var controller = new HomeController();
            var game_list = Game.FakeData.Generate(3);

            //Act

            var actionResult = await controller.PostAsync(game_list);

            // Assert
            Assert.Equal(400, (actionResult.Result as ObjectResult)?.StatusCode);
        }
    }
}
