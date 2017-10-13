﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGLib
{
    public class CommandSequence
    {
        // using strings to represent input at the moment...
        private string _activatesOn;
        private List<string> _commands;

        public CommandSequence(List<string> orderedCommands)
        {
            _commands = orderedCommands;
            _activatesOn = _commands.Last();
        }
    }
}
