using SharedTools;
using System.Diagnostics;

namespace Day01_NotQuiteLisp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var timer = new Stopwatch();
            timer.Start();

            var fileReader = new FileReader("input.txt", ReadOption.All);
            var elevatorLogic = new ElevatorLogic(fileReader.Text, '(', ')');

            Console.WriteLine($"Part 1: {elevatorLogic.SolveOne()} | done in: {timer.ElapsedMilliseconds}ms");

            timer.Restart();

            Console.WriteLine($"Part 2: {elevatorLogic.SolveTwo()} | done in: {timer.ElapsedMilliseconds}ms");
        }

    }
}