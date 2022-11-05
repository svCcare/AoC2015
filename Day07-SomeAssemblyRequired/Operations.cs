namespace Day07_SomeAssemblyRequired
{
    internal class Operations
    {
        public Dictionary<string, Info> OperationsDictionary { get; set; } = new();

        public int GetValueOfItem(string item)
        {
            if (int.TryParse(item, out int variableValue))
            {
                return variableValue;
            }

            var currentItem = OperationsDictionary[item];

            if (currentItem.VariableValue != null) { return currentItem.VariableValue.Value; };

            switch (currentItem.OperationType)
            {
                case OperationType.AND:
                    currentItem.VariableValue = GetValueOfItem(currentItem.DependencyOne) & GetValueOfItem(currentItem.DependencyTwo);
                    return currentItem.VariableValue.Value;

                case OperationType.OR:
                    currentItem.VariableValue = GetValueOfItem(currentItem.DependencyOne) | GetValueOfItem(currentItem.DependencyTwo);
                    return currentItem.VariableValue.Value;

                case OperationType.NOT:
                    currentItem.VariableValue = ~GetValueOfItem(currentItem.DependencyOne) + 65536;
                    return currentItem.VariableValue.Value;

                case OperationType.LSHIFT:
                    currentItem.VariableValue = GetValueOfItem(currentItem.DependencyOne) << currentItem.ShiftCount;
                    return currentItem.VariableValue.Value;

                case OperationType.RSHIFT:
                    currentItem.VariableValue = GetValueOfItem(currentItem.DependencyOne) >> currentItem.ShiftCount;
                    return currentItem.VariableValue.Value;

                case OperationType.ASSIGN:
                    currentItem.VariableValue = GetValueOfItem(currentItem.DependencyOne);
                    return currentItem.VariableValue.Value;
                default:
                    break;
            }

            return -1;
        }

    }
}
