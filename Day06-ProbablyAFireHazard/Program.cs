﻿using SharedTools;

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



            Console.WriteLine($"Part 1:");
            Console.WriteLine($"Part 2:");
        }

    }
}