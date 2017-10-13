

namespace FGLib
{
    public class Move
    {
        public string Name { get; }
        private CommandSequence _moveCommand;

        public Move(string name, CommandSequence command)
        {
            Name = name;
            _moveCommand = command;
        }
    }
}
