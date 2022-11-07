namespace Day08_Matchsticks
{
    internal class CharactersCalculator
    {
        char escapeChar = '\\';
        string hexChar = "\\x";

        public List<(int physicalCount, int logicalCount)> Characters { get; set; } = new();

        internal void Calculate(string line)
        {
            var physical = line.Length;

            var logical = CalculateLogicalLength(line);

            Characters.Add((physical, logical));
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