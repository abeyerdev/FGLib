using System.Collections.Generic;

namespace FGLib
{
    public class Character
    {
        public string Name { get; }
        public List<Move> MoveList { get; }

        public Character(string name, List<Move> moveList)
        {
            Name = name;
            MoveList = moveList;
        }
    }
}
