using SharedTools;

namespace Day05_DoesntHeHaveInternElvesForThis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.Lines);

            Validator validator = new Validator(fileReader.TextLines);
            validator.Solve();


            Console.WriteLine($"Part 1:");
            Console.WriteLine($"Part 2:");
        }

    }
}