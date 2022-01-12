using GameCup.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GameCup.test
{
    public class GameModel
    {
        [Fact]
        public async Task ReturnListEliminatoriasGameBehavor()
        {
            // Arrange
            int count = 4;
            var model = new Game();
            var game_list = Game.FakeData.Generate(8);

            //Act
            var functionResult = model.Eliminatorias(game_list);

            //Asset
            Assert.IsType<List<Game>>(functionResult);
            Assert.Equal(count, functionResult.Count);
        }

        [Fact]
        public async Task ReturnListWinnerFinalBehavor()
        {
            // Arrange
            int count = 2;
            var model = new Game();
            var game_list = Game.FakeData.Generate(4);

            //Act

            var functionResult = model.Final(game_list);

            // Assert
            Assert.IsType<List<Game>>(functionResult);
            Assert.Equal(count, functionResult.Count);
        }
    }
}
