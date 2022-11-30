namespace Day23_OpeningTheTuringLock
{
    public enum InstructionType {
        hlf, // half current value
        tpl, // triple current value
        inc, // increments current value
        jmp, // jump // jpm +1 doesnt do anything special, can be -1 to jump step back
        jie, // jump if current value is even
        jio // jump if current value is equal to 1
    }
}
