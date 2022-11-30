namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class HalfAction : ActionBase, IAction
    {
        public HalfAction()
        {
            Type = InstructionType.hlf;
        }

        public int Call(int value)
        {
            return value / 2;
        }
    }
}
