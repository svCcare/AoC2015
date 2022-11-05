namespace Day06_ProbablyAFireHazard
{
    internal class Instruction
    {
        private OperationType _operationType;
        private (int, int) _xCoordinates;
        private (int, int) _yCoordinates;

        internal Instruction(string operationString, (int, int) xCoordinates, (int, int) yCoordinates)
        {
            _operationType = SetOperation(operationString);
            _xCoordinates = xCoordinates;
            _yCoordinates = yCoordinates;
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
