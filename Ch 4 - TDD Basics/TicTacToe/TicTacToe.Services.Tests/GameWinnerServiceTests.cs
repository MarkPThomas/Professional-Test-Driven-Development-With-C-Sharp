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
        private IGameWinnerService _gameWinnerService;
        private char[,] _gameboard;

        [SetUp]
        public void SetupUnitTests()
        {
            _gameWinnerService = new GameWinnerService();
            _gameboard = new char[3, 3] { {' ', ' ', ' ' },
                                          {' ', ' ', ' ' },
                                          {' ', ' ', ' ' }};
        }

        [Test]
        public void NeitherPlayerHasThreeInARow()
        {
            const char expected = ' ';
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void NeitherPlayerHasThreeInARowButOneOnDiagonal()
        {
            const char expected = ' ';
            _gameboard[1, 1] = 'X';
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void PlayerWithAllSpacesInTopRowIsWinner()
        {
            const char expected = 'X';
            for (var rowIndex = 0; rowIndex < 3; rowIndex++)
            {
                _gameboard[0, rowIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithAllSpacesInFirstColumnIsWinner()
        {
            const char expected = 'X';
            for (var columnIndex = 0; columnIndex < 3; columnIndex++)
            {
                _gameboard[columnIndex, 0] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }

        [Test]
        public void PlayerWithThreeInARowDiagonallyDownAndToRightIsWinner()
        {
            const char expected = 'X';
            for (var cellIndex = 0; cellIndex < 3; cellIndex++)
            {
                _gameboard[cellIndex, cellIndex] = expected;
            }
            var actual = _gameWinnerService.Validate(_gameboard);
            Assert.AreEqual(expected.ToString(), actual.ToString());
        }
    }
}
