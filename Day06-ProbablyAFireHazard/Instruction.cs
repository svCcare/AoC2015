namespace Day06_ProbablyAFireHazard
{
    internal class Instruction
    {
        internal OperationType OperationType { get; }
        internal (int, int) XCoordinates { get; }
        internal (int, int) YCoordinates { get; }

        private Instruction() { }

        internal Instruction(string operationString, (int, int) xCoordinates, (int, int) yCoordinates)
        {
            OperationType = SetOperation(operationString);
            XCoordinates = xCoordinates;
            YCoordinates = yCoordinates;
        }

        private OperationType SetOperation(string operationString) =>
            operationString switch
            {
                "turn on " => OperationType.TurnOn,
                "turn off " => OperationType.TurnOff,
                "toggle " => OperationType.Toggle,
                _ => throw new ArgumentException("Invalid string value for command", nameof(operationString)),
            };
    }
}
