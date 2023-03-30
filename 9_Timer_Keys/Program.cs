using System.Timers;

namespace _9_Timer_Keys
{
    class Program
    {
        enum Direction { UP, RIGHT, DOWN, LEFT };
        static Direction d = Direction.RIGHT;
        static int x = 0, y = 0;
        static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(60);
            
            // public event ElapsedEventHandler Elapsed - это событие происходит по истечении интервала времени
            t.Elapsed += new ElapsedEventHandler(OnTimer);
            t.Start(); // Начинает вызывать событие Elapsed
            ConsoleKey key;
            Console.CursorVisible = false;
            do
            {
                ConsoleKeyInfo info = Console.ReadKey();
                key = info.Key;
                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        d = Direction.LEFT;
                        break;
                    case ConsoleKey.RightArrow:
                        d = Direction.RIGHT;
                        break;
                    case ConsoleKey.UpArrow:
                        d = Direction.UP;
                        break;
                    case ConsoleKey.DownArrow:
                        d = Direction.DOWN;
                        break;
                }
            } while (key != ConsoleKey.Escape);
        }

        private static void OnTimer(object? sender, ElapsedEventArgs arg /* Предоставляет данные для события Elapsed */)
        {
            switch (d)
            {
                case Direction.UP:
                    if (y > 0)
                        --y;
                    break;
                case Direction.RIGHT:
                    if (x < Console.WindowWidth - 1)
                        ++x;
                    break;
                case Direction.DOWN:
                    if (y < Console.WindowHeight - 1)
                        ++y;
                    break;
                case Direction.LEFT:
                    if (x > 0)
                        --x;
                    break;
            }

            //Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write((char)2);
        }
    }
}