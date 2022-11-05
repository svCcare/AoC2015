using SharedTools;
using System.Diagnostics;

namespace Day07_SomeAssemblyRequired
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);
            //Dictionary<string, Info> operations = new Dictionary<string, Info>();
            Operations operations = new Operations();

            var timer = new Stopwatch();
            timer.Start();
            foreach (var line in fileReader.TextLines)
            {
                (string key, Info info) decoded = InputDecoder.TranslateInput(line);
                operations.OperationsDictionary.Add(decoded.key, decoded.info);
            }

            var result = operations.GetValueOfItem("a");
            Console.WriteLine($"Part 1: {result}, time elapsed: {timer.ElapsedMilliseconds}ms");

            //Now, take the signal you got on wire a, override wire b to that signal, and reset the other wires (including wire a). What new signal is ultimately provided to wire a?
            var timer2 = new Stopwatch();
            timer2.Start();

            operations.OperationsDictionary.Clear();
            foreach (var line in fileReader.TextLines)
            {
                (string key, Info info) decoded = InputDecoder.TranslateInput(line);
                operations.OperationsDictionary.Add(decoded.key, decoded.info);
            }

            operations.OperationsDictionary["b"].VariableValue = result;
            var part2result = operations.GetValueOfItem("a");
            Console.WriteLine($"Part 1: {part2result}, time elapsed: {timer2.ElapsedMilliseconds}ms");
        }
    }
}