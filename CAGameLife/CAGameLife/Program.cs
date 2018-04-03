using System;

namespace CAGameLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Зацикливаем и жмём Enter для отображения фигурки которую я загуглил под названием "Мигалка", для выхода пишем "q" и клацаем Enter
            var grid = new LiveGrid();
            grid.CurrentState[1, 2] = LiveState.Alive;
            grid.CurrentState[2, 2] = LiveState.Alive;
            grid.CurrentState[3, 2] = LiveState.Alive;

            ShowGrid(grid.CurrentState);

            while (Console.ReadLine() != "q")
            {
                grid.UpdateState();
                ShowGrid(grid.CurrentState);
            }
        }

        // Показуем сетку и очищаем предыдущую
        private static void ShowGrid(LiveState[,] currentState)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("=====[Игра GameLife]=====");
            Console.ResetColor();
            int x = 0;
            int rowLength = 5;

            foreach (var state in currentState)
            {
                var output = state == LiveState.Alive ? "O" : "·";
                Console.Write(output);
                x++;
                if (x >= rowLength)
                {
                    x = 0;
                    Console.WriteLine();
                }
            }
        }
    }
}
