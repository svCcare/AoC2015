namespace Day06_ProbablyAFireHazard
{
    internal static class InputDecoder
    {
        internal static Instruction TranslateInput(string input)
        {
            var operation = string.Concat(input.TakeWhile(sign => !char.IsDigit(sign)));

            var allCoordinates = input.Substring(operation.Length).Split(" through ");

            var from = allCoordinates[0].Split(',');
            var to = allCoordinates[1].Split(',');

            var instruction = new Instruction(
                operation,
                (Convert.ToInt16(from[0]), Convert.ToInt16(to[0])),
                (Convert.ToInt16(from[1]), Convert.ToInt16(to[1])));

            return instruction;
        }


    }
}
