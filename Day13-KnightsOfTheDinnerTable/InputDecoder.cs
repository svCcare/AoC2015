namespace Day13_KnightsOfTheDinnerTable
{
    internal class InputDecoder
    {
        internal static IEnumerable<(string from, string to, int score)> Decode(string[] lines)
        {
            var decodedLines = lines.Select(line => line.Split(' '));

            return decodedLines.Select(decoded => (
                decoded[0],
                decoded[10].Replace(".", string.Empty),
                decoded[2] == "gain" ? Convert.ToInt32(decoded[3]) : Convert.ToInt32(decoded[3]) * -1));
        }
    }
}
