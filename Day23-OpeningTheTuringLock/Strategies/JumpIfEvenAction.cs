namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class JumpIfEvenAction : ActionBase, IAction
    {
        public JumpIfEvenAction()
        {
            Type = InstructionType.jie;
        }

        public int Call(int value)
        {
            return 0;
        }
    }
}
