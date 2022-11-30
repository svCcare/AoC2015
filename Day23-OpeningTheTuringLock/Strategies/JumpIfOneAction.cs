namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class JumpIfOneAction : ActionBase, IAction
    {
        public JumpIfOneAction()
        {
            Type = InstructionType.jio;
        }

        public int Call(int valie)
        {
            return 0;
        }
    }
}
