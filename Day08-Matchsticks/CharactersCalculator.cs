using System.Text.RegularExpressions;

namespace Day08_Matchsticks
{
    internal class CharactersCalculator
    {
        char escapeChar = '\\';
        string hexChar = "\\x";

        char quote = '"';

        public List<(int physicalCount, int logicalCount, int encodedPhysical)> Characters { get; set; } = new();

        internal void Calculate(string line)
        {
            var physical = line.Length;

            var encodedPhysical = CalculatePhysicalLength(line);

            var logical = 0; // CalculateLogicalLength(line);

            Characters.Add((physical, logical, encodedPhysical));
        }
        internal int CalculatePhysicalLength(string line) // "\xa8br\x8bjr\""
        {
            int lineLenght = 2; // always ""

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == quote)
                {
                    lineLenght += 2;
                }
                else if (line[i].ToString() + line[i + 1] == hexChar)
                {
                    if (i + 4 > line.Length) // might be \x at the very end
                    {
                        lineLenght += 2;
                    }
                    else if (!Regex.IsMatch(line.Substring(i, 4), @"\\[xX][0-9a-fA-F][0-9a-fA-F]"))
                    {
                        lineLenght += 2;
                    }
                    else // proper \x00 format
                    {
                        i += 3;
                        lineLenght += 5;
                    }
                }
                else if (line[i] == escapeChar)
                {
                    lineLenght += 2;
                }
                else
                {
                    lineLenght++;
                }
            }

            return lineLenght;
        }

        internal int CalculateLogicalLength(string line) // "\xa8br\x8bjr\""
        {
            int lineLenght = 0;
            line = line.Substring(1, line.Length - 2); // removing " " wrappers

            for (int i = 0; i < line.Length; i++)
            {
                if (line[i] == escapeChar)
                {
                    if (line[i].ToString() + line[i + 1] == hexChar)
                    { // its \x case
                        i += 3;
                        lineLenght++;
                    }
                    else
                    {
                        i += 1;
                        lineLenght++;
                    }
                }
                else
                {
                    lineLenght++;
                }
            }

            // \xa8br\x8bjr\"
            // \xa8 = 1 logical
            // b
            // r
            // \x8b = 1 logical
            // j
            // r
            // \" = 1 logical

            return lineLenght;
        }
    }
}