using SharedTools;

namespace Day03_PerfectlySphericalHousesInAVacuum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader("input.txt", ReadOption.All);

            var santaDelivery = new SantaDelivery(fileReader.Text);
            santaDelivery.BeginDelivery();
            Console.WriteLine($"Part 1: {santaDelivery.GetAddressCheckListCount()}");

            var santaBotDelivery = new SantaBotDelivery(fileReader.Text);
            santaBotDelivery.BeginDelivery();
            Console.WriteLine($"Part 2: {santaBotDelivery.GetAddressCheckListCount()}");
        }

    }
}