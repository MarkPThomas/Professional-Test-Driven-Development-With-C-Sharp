using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

using TicTacToe.Services;

namespace TicTacToe.UnitTests
{
    [TestFixture]
    public class GameWinnerServiceTests
    {
        [Test]
        public void NeitherPlayerHasThreeInARow()
        {
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            const char expected = ' ';
            var gameBoard = new char[3, 3] { {' ', ' ', ' ' },
                                             {' ', ' ', ' ' },
                                             {' ', ' ', ' ' }};
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            IGameWinnerService gameWinnerService;
            gameWinnerService = new GameWinnerService();
            const char expected = 'X';
            var gameBoard = new char[3, 3] { {expected, expected, expected },
                                             {' ', ' ', ' ' },
                                             {' ', ' ', ' ' }};
            var actual = gameWinnerService.Validate(gameBoard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
