namespace Day07_SomeAssemblyRequired
{
    internal static class InputDecoder
    {
        internal static (string key, Info info) TranslateInput(string input)
        {
            var key = input.Substring(input.Length - 2).Trim();

            // return (string key, Info info)
            Info info = new();

            var leftPart = input.Substring(0, input.IndexOf("->")).Trim();

            if (leftPart.Contains("AND"))
            {
                var parts = leftPart.Split(" AND ");
                info.DependencyOne = parts[0];
                info.DependencyTwo = parts[1];

                info.OperationType = OperationType.AND;
            }

            else if (leftPart.Contains("OR"))
            {
                var parts = leftPart.Split(" OR ");
                info.DependencyOne = parts[0];
                info.DependencyTwo = parts[1];

                info.OperationType = OperationType.OR;
            }

            else if (leftPart.Contains("NOT"))
            {
                var part = leftPart.Substring("NOT ".Length);
                info.DependencyOne = part;

                info.OperationType = OperationType.NOT;
            }

            else if (leftPart.Contains("LSHIFT"))
            {
                var parts = leftPart.Split(" LSHIFT ");
                info.DependencyOne = parts[0];
                info.ShiftCount = Convert.ToInt32(parts[1]);

                info.OperationType = OperationType.LSHIFT;
            }
            else if (leftPart.Contains("RSHIFT"))
            {
                var parts = leftPart.Split(" RSHIFT ");
                info.DependencyOne = parts[0];
                info.ShiftCount = Convert.ToInt32(parts[1]);

                info.OperationType = OperationType.RSHIFT;
            }

            else if (!char.IsDigit(leftPart[0]))
            {
                info.DependencyOne = leftPart;
                info.OperationType = OperationType.ASSIGN;
            }

            else
            {
                info.VariableValue = Convert.ToInt32(leftPart);
            }

            return (key, info);
        }
    }

    internal class Info
    {
        public int? VariableValue { get; set; }

        public string DependencyOne { get; set; }

        public string DependencyTwo { get; set; }

        public OperationType OperationType { get; set; }

        public int ShiftCount { get; set; }
    }

    public enum OperationType
    {
        AND,
        OR,
        NOT,
        LSHIFT,
        RSHIFT,
        ASSIGN,
    }
}


// Dictionary<string, Info>
// Info(int value, IEnumerable<string> DependingOn, Operation operation)