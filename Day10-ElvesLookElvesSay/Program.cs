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
            //StringBuilder sb = new();
            Stopwatch timer = new();
            timer.Start();

            var text = new FileReader("input.txt", ReadOption.All).Text;

            for (int i = 0; i < 50; i++) // iterate 40 times
            {
                text = Step(text, sbTemp);
                sbTemp.Clear();

                //sb.Append(Step(sb.ToString(), sbTemp));
                //sbTemp.Clear();
                //sb.Clear();
            }

            Console.WriteLine($"Part 2: {text.Length}, time elapsed: {timer.ElapsedMilliseconds}ms");
        }


        private static string Step(string currentText, StringBuilder builder)
        {
            List<string> phrases = new();

            var currentDigit = currentText[0];
            var digitCounter = 0;

            for (int i = 0; i < currentText.Length; i++)
            {
                digitCounter++;
                currentDigit = currentText[i];

                if (i + 1 == currentText.Length || currentText[i + 1] != currentDigit)
                {
                    phrases.Add(digitCounter.ToString() + currentDigit);
                    digitCounter = 0;
                }
            }

            foreach (var phrase in phrases)
            {
                builder.Append(phrase);
            }

            return builder.ToString();
        }

    }
}