using SharedTools;

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

            HouseDecoration houseDecoration = new();
            houseDecoration.ExecuteInstructions(operations);


            Console.WriteLine($"Part 1: {houseDecoration.CountLightedUp()}");
            Console.WriteLine($"Part 2:");
        }

    }
}