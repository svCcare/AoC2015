namespace Day01_NotQuiteLisp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new SharedTools.FileReader("input.txt");
            var elevatorLogic = new ElevatorLogic(fileReader.Text, '(', ')');

            Console.WriteLine($"Part 1: {elevatorLogic.SolveOne()}");
            Console.WriteLine($"Part 2: {elevatorLogic.SolveTwo()}");
        }

    }
}