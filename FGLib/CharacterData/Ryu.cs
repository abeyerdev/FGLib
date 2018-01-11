using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FGLib.CharacterData
{
    public class Ryu
    {
        public static List<Move> GetMoveList()
        {
            List<Move> moveList = new List<Move>();

            //List<ConsoleKey> fireballCommandList = new List<ConsoleKey>()
            //{
            //    ConsoleKey.DownArrow,
            //    ConsoleKey.RightArrow,
            //    ConsoleKey.P
            //};
            //Move fireball = new Move(new CommandSequence<Input>(fireballCommandList), "Hadouken", 5, true);
            //moveList.Add(fireball);

            return moveList;
        }
    }
}
