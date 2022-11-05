using SharedTools;
using System.Diagnostics;

namespace Day06_ProbablyAFireHazard
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);

            var operations = new Instruction[300];

            foreach (var (item, index) in fileReader.TextLines.WithIndex())
            {
                operations[index] = InputDecoder.TranslateInput(item);
            }

            var timer = new Stopwatch();
            timer.Start();

            HouseDecoration houseDecoration = new();
            houseDecoration.ExecuteInstructions(operations);


            //Console.WriteLine($"Part 1: {houseDecoration.CountLightedUp()} | elapsed: {timer.ElapsedMilliseconds}ms");
            Console.WriteLine($"Part 2: {houseDecoration.CalculateBrightness()} | elapsed: {timer.ElapsedMilliseconds}ms");
        }

    }
}