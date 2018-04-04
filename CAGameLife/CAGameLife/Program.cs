using System;

namespace CAGameLife
{
    class Program
    {
        static void Main(string[] args)
        {
            // Зацикливаем и жмём Enter для отображения фигурки которую я загуглил под названием "Мигалка", для выхода пишем "q" и клацаем Enter
            var grid = new LiveGrid();
            //grid.CurrentState[1, 2] = LiveState.Alive;
            //grid.CurrentState[2, 2] = LiveState.Alive;
            //grid.CurrentState[3, 2] = LiveState.Alive;

            //Доделал фигурку Планер
            grid.CurrentState[2, 1] = LiveState.Alive;
            grid.CurrentState[2, 2] = LiveState.Alive;
            grid.CurrentState[0, 2] = LiveState.Alive;
            grid.CurrentState[2, 3] = LiveState.Alive;
            grid.CurrentState[1, 3] = LiveState.Alive;

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
            int rowLength = 25;
            //string a = "O";
            //string b = "·";
            string a = " ";
            string b = " ";
            var output = "";

            foreach (var state in currentState)
            {
                //var output = state == LiveState.Alive ? "O" : "·";
                if (state == LiveState.Alive)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    output = a;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Green;
                    output = b;
                }

                Console.Write(output);
                Console.ResetColor();
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
