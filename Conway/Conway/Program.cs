using System;
using System.Threading;

namespace Conway
{
    class Program
    {
        static void Main(string[] args)
        {
            var board = Board.GetGlider(15);

            for (int i = 0; i < 100; i++)
            {
                Console.Clear();
                Console.Write(board.Render());
                board.Update();
                Thread.Sleep(500);
            }
        }
    }
}
