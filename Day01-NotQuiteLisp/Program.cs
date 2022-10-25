namespace Day01_NotQuiteLisp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fl = new FileReader("input.txt");
            var ello = new ElevatorLogic(fl.Text, '(', ')');
        }

    }
}