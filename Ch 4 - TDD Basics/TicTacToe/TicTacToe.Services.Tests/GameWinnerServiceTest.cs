// <copyright file="GameWinnerServiceTest.cs">Copyright ©  2016</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using NUnit.Framework;
using TicTacToe.Services;

namespace TicTacToe.Services.Tests
{
    /// <summary>This class contains parameterized unit tests for GameWinnerService</summary>
    [PexClass(typeof(GameWinnerService))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestFixture]
    public partial class GameWinnerServiceTest
    {
        /// <summary>Test stub for Validate(Char[,])</summary>
        [PexMethod]
        public char ValidateTest([PexAssumeUnderTest]GameWinnerService target, char[,] gameBoard)
        {
            char result = target.Validate(gameBoard);
            return result;
            // TODO: add assertions to method GameWinnerServiceTest.ValidateTest(GameWinnerService, Char[,])
        }
    }
}
