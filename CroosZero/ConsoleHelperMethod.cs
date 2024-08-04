using System;

namespace CSharpCrossZeroSolution
{
    public class ConsoleHelperMethod
    {
        private char[,] _board;
        private bool _checkTurn = true;
        public void GoGame()
        {
            _board = new char[3, 3];
            InitBoard();
            PrintBoard();

            while (true)
            {
                if (_checkTurn)
                    PlayerTurn();
                else
                    ComputerTurn();

                if (CheckForWin())
                {
                    PrintBoard();
                    Console.ReadKey();
                    return;
                }

                _checkTurn = !_checkTurn;
                PrintBoard();
            }
        }

        private void PlayerTurn()
        {
            Console.WriteLine("Ваш ход: ");
            PlayerMove playerMove = new PlayerMove();
            IAbstractMove move = playerMove.NextMove();
            Console.WriteLine(move.ExecuteMove(_board));
            
        }

        private void ComputerTurn()
        {
            Console.WriteLine("Ход компьютера: ");
            ComputerMove computerMove = new ComputerMove();
            IAbstractMove move = computerMove.NextMove();
            Console.WriteLine(move.ExecuteMove(_board));
            Console.ReadKey();
        }

        private bool CheckForWin()
        {
            if (Checker('X'))
            {
                Console.WriteLine("Вы выиграли. Игра окончена");
                Console.ReadKey();
                return true;
            }
            else if (Checker('O'))
            {
                Console.WriteLine("Компьютер выиграл. Игра окончена");
                Console.ReadKey();
                return true;
            }
            return false;
        }
        private void InitBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                    _board[i, j] = ' ';
            }
        }
        private void PrintBoard()
        {
            Console.Clear();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(_board[i, j]);
                    if (j < 2)
                        Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2)
                    Console.WriteLine("---------");
            }
        }

        private bool Checker(char p)
        {
            for (int i = 0; i < 3; i++)
            {
                if (_board[i, 0] == p && _board[i, 1] == p && _board[i, 2] == p ||
                    _board[0, i] == p && _board[1, i] == p && _board[2, i] == p ||
                    _board[0, 0] == p && _board[1, 1] == p && _board[2, 2] == p ||
                    _board[0, 2] == p && _board[1, 1] == p && _board[2, 0] == p)
                    return true;
            }
            return false;
        }
    }
}