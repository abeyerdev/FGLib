using System;
using System.Collections.Generic;
using System.Linq;

namespace FGLib
{
    public class CommandSequence<T>
    {
        public T ActivatesOn { get; }
        public List<T> Commands;

        public CommandSequence(List<T> orderedCommands)
        {            
            ActivatesOn = orderedCommands.Last();
            orderedCommands.Remove(ActivatesOn);
            Commands = orderedCommands;
        }        
    }
}
