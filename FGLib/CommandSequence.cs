using System;
using System.Collections.Generic;
using System.Linq;
using FGLib.InputHandling;

namespace FGLib
{
    public class CommandSequence
    {
        public Input ActivatesOn { get; }
        public List<Input> Commands;

        public CommandSequence(List<Input> orderedCommands)
        {
            ActivatesOn = orderedCommands.Last();
            orderedCommands.Remove(ActivatesOn);
            Commands = orderedCommands;
        }
    }
}
