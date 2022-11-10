using SharedTools;
using System.Diagnostics;
using System.Text;

namespace Day10_ElvesLookElvesSay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sbTemp = new();
            Stopwatch timer = new();
            timer.Start();

            var text = new FileReader("input.txt", ReadOption.All).Text;

            for (int i = 0; i < 50; i++)
            {
                text = Step(text, sbTemp);
                sbTemp.Clear();
            }

            Console.WriteLine($"Part 2: {text.Length}, time elapsed: {timer.ElapsedMilliseconds}ms");
        }

        private static string Step(string currentText, StringBuilder builder)
        {
            var repetitions = 0;
            var textLenght = currentText.Length;

            for (int i = 0; i < textLenght; i++)
            {
                repetitions++;
                var currentDigit = currentText[i];

                if (FinishSubgroup(i, textLenght, currentText))
                {
                    builder.Append(repetitions.ToString() + currentDigit);
                    repetitions = 0;
                }
            }

            return builder.ToString();
        }

        private static bool FinishSubgroup(int i, int textLenght, string text)
        {
            return i + 1 == textLenght || text[i] != text[i + 1];
        }
    }
}