namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class TripleAction : ActionBase, IAction
    {
        public TripleAction()
        {
            Type = InstructionType.tpl;
        }

        public int Call(int value)
        {
            return value * 3;
        }
    }
}
