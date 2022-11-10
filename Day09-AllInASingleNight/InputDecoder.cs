namespace Day09_AllInASingleNight
{
    internal static class InputDecoder
    {
        internal static IEnumerable<(string from, string to, string distance)> Decode(string[] lines)
        {
            var decodedLines = lines.Select(line => line.Split(' '));
            return decodedLines.Select(decoded => (decoded[0], decoded[2], decoded[4]));
        }
    }
}
