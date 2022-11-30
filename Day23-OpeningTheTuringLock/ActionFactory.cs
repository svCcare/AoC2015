namespace Day23_OpeningTheTuringLock
{
    using Day23_OpeningTheTuringLock.Strategies;

    internal class ActionFactory
    {
        internal IAction Build(string input)
        {
            var splitted = input.Split(' ');

            switch (splitted[0])
            {
                case "hlf":
                    return new HalfAction(); ;
                case "tpl":
                    return new TripleAction(); ;
                case "inc":
                    return new IncrementAction();
                case "jmp":
                    return new JumpAction(Convert.ToInt32(splitted[1])); ;
                case "jie":
                    return new JumpIfEvenAction(); ;
                case "jio":
                    return new JumpIfOneAction(); ;
                default:
                    return new IncrementAction(); ;
            }
        }
    }
}
