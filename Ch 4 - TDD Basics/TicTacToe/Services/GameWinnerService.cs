using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.Services
{
    public class GameWinnerService : IGameWinnerService
    {
        private const char SymbolForNoWinner = ' ';

        public char Validate(char[,] gameBoard)
        {
            if (!CheckForValidGameBoard(gameBoard)) { return SymbolForNoWinner; }
            
            var currentWinningSymbol =  CheckForThreeInARowInHorizontalRow(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner) { return currentWinningSymbol; }

            currentWinningSymbol = CheckForThreeInARowInVerticalColumn(gameBoard);
            if (currentWinningSymbol != SymbolForNoWinner) { return currentWinningSymbol; }

            currentWinningSymbol = CheckForThreeInARowDiagonally(gameBoard);
            return currentWinningSymbol;
        }

        private static bool CheckForValidGameBoard(char[,] gameBoard)
        {
            if (gameBoard == null) { return false; }

            if ((gameBoard.GetLength(0) != 3) ||
                (gameBoard.GetLength(1) != 3)) { return false; }

            return true;
        }
        private static char CheckForThreeInARowInHorizontalRow(char[,] gameBoard)
        {
            var columnOneChar = gameBoard[0, 0];
            var columnTwoChar = gameBoard[0, 1];
            var columnThreeChar = gameBoard[0, 2];
            if (columnOneChar == columnTwoChar &&
                columnTwoChar == columnThreeChar)
            {
                return columnOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowInVerticalColumn(char[,] gameBoard)
        {
            var rowOneChar = gameBoard[0, 0];
            var rowTwoChar = gameBoard[1, 0];
            var rowThreeChar = gameBoard[2, 0];
            if (rowOneChar == rowTwoChar &&
                rowTwoChar == rowThreeChar)
            {
                return rowOneChar;
            }
            return SymbolForNoWinner;
        }

        private static char CheckForThreeInARowDiagonally(char[,] gameBoard)
        {
            var cellOneChar = gameBoard[0, 0];
            var cellTwoChar = gameBoard[1, 1];
            var cellThreeChar = gameBoard[2, 2];

            if (cellOneChar == cellTwoChar &&
                cellTwoChar == cellThreeChar)
            {
                return cellOneChar;
            }
            return SymbolForNoWinner;
        }
    }
}
