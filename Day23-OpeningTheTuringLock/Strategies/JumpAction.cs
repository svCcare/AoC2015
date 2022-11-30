namespace Day23_OpeningTheTuringLock.Strategies
{
    internal class JumpAction : ActionBase, IAction
    {
        public JumpAction()
        {
            Type = InstructionType.jmp;
        }

        public JumpAction(int jumpCount): base()
        {

        }

        public int Call(int value)
        {
            return 0;
        }
    }
}
