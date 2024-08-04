using System;

namespace CSharpCrossZeroSolution
{
    public interface IAbstractMove
    {
        string ExecuteMove(char[,] Board);
    }

    public class HumanMove : IAbstractMove
    {
        public string ExecuteMove(char[,] Board)
        {
            while (true)
            {
                Console.WriteLine("Введите номер клетки куда будете стрелять (клетки 1 - 9) ");
                string xod = Console.ReadLine();

                if (int.TryParse(xod, out int cellResult) && cellResult >= 1 && cellResult <= 9)
                {
                    int i = (cellResult - 1) / 3;
                    int j = (cellResult - 1) % 3;

                    if (Board[i, j] == ' ')
                    {
                        Board[i, j] = 'X';
                        return $"Вы сделали ход в клетку {cellResult}";
                    }

                    Console.WriteLine("Эта клетка занята, попробуйте снова.");
                }
                else
                {
                    Console.WriteLine("Некорректный ввод! Вводите число от 1 до 9.");
                }
            }
        }
    }

    public class AILogicMove : IAbstractMove
    {
        public string ExecuteMove(char[,] Board)
        {
            Random rand = new Random();
            do
            {
                int cellResult = rand.Next(1, 10);
                int i = (cellResult - 1) / 3;
                int j = (cellResult - 1) % 3;

                if (cellResult >= 1 && cellResult <= 9 && Board[i, j] != 'X' && Board[i, j] != 'O')
                {
                    Board[i, j] = 'O';
                    return $"Компьютер стрельнул в {cellResult}. Нажми людую клавишу";
                }
            } while (true);
        }
    }
}