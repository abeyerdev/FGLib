using System;

namespace FGLib
{
    public class Move
    {
        public string Name { get; }
        public CommandSequence Command { get; }
        public bool FlushBuffer { get; }
        public int Priority { get; }

        public Move(CommandSequence command, string name = "Unnamed Move", int priority = 0, bool flushBuffer = false)
        {
            Command = command;
            Name = name;
            Priority = priority;
            FlushBuffer = flushBuffer;
        }
    }
}
