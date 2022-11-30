namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class IncrementAction : ActionBase, IAction
    {
        public IncrementAction()
        {
            Type = InstructionType.inc;
        }

        public int Call(int value)
        {
            return value + 1;
        }
    }
}
