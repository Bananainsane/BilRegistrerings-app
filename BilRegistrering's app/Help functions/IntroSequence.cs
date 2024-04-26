using System;
using System.Threading;

namespace BilRegistrering_s_app
{
    public static class IntroSequence
    {
        public static void Show()
        {
            Console.WindowWidth = 120;
            Console.WindowHeight = 40;

            DrawDoubleBorder();

            AnimateTitle("CAR REGISTRATION AND INSPECTION", ConsoleColor.Cyan, 50);
            Thread.Sleep(500);  // Pause after title animation
            AnimateTitle("Press any key to continue...", ConsoleColor.Yellow, 25, true);


            Console.ReadKey();
            Console.Clear();
        }

        private static void DrawDoubleBorder()
        {
            Console.Clear();

            string horizontal = "═";
            string vertical = "║";
            string topLeft = "╔";
            string topRight = "╗";
            string bottomLeft = "╚";
            string bottomRight = "╝";

            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write(horizontal);
                Console.SetCursorPosition(i, Console.WindowHeight - 1);
                Console.Write(horizontal);
                Thread.Sleep(5);
            }

            for (int j = 0; j < Console.WindowHeight; j++)
            {
                Console.SetCursorPosition(0, j);
                Console.Write(vertical);
                Console.SetCursorPosition(Console.WindowWidth - 1, j);
                Console.Write(vertical);
                Thread.Sleep(5);
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(topLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, 0);
            Console.Write(topRight);
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write(bottomLeft);
            Console.SetCursorPosition(Console.WindowWidth - 1, Console.WindowHeight - 1);
            Console.Write(bottomRight);
        }

        private static void AnimateTitle(string title, ConsoleColor color, int delay, bool newLine = false)
        {
            Console.ForegroundColor = color;

            int x = (Console.WindowWidth - title.Length) / 2;
            int y = (Console.WindowHeight / 2);
            if (newLine) y++;

            foreach (char ch in title)
            {
                Console.SetCursorPosition(x, y);
                Console.Write(ch);
                x++;
                Thread.Sleep(delay);
            }

            Console.ResetColor();
        }

    }
}
