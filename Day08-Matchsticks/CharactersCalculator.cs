using System.Text.RegularExpressions;

namespace Day08_Matchsticks
{
    internal class CharactersCalculator
    {
        private readonly char escapeChar = '\\';
        private readonly char quote = '"';
        private readonly string hexChar = "\\x";
        private readonly string hexCharPattern = "@\"\\\\[xX][0-9a-fA-F][0-9a-fA-F]\"";

        internal int[] Results { get; set; } = new int[2];

        internal void Calculate(string line)
        {
            var physical = line.Length;

            var encodedPhysical = CalculatePhysicalLength(line);

            var logical = CalculateLogicalLength(line);

            Results[0] += physical - logical;
            Results[1] += encodedPhysical - physical;
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
                    else if (!Regex.IsMatch(line.Substring(i, 4), hexCharPattern))
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

            return lineLenght;
        }
    }
}