using System;
using System.Collections.Generic;
using System.Linq;

namespace FGLib
{
    /// <summary>
    /// Provides functionality for controlling the resolution
    /// of player inputs.
    /// </summary>
    public class InputBuffer
    {
        private const int DEFAULT_BUFFER_SIZE = 60;
        private CircularQueue<ConsoleKey> _buffer;
        public PlayerInfo Player { get; }

        public InputBuffer(PlayerInfo player, int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            _buffer = new CircularQueue<ConsoleKey>(bufferSize);
            Player = player;
        }

        public Move AddAndResolveInput(ConsoleKey input)
        {
            _buffer.Add(input);            
            return MatchInputsToMoveList(input);
        }

        /**
        * Every frame, after adding in the most recent input (and hence removing the last one, 
        * since it's a circular buffer), you go from the oldest to the most recent identifying any 
        * patterns that translate into moves (it's as simple as looking if there's a down, followed 
        * at some point by a down-forward, followed at some point by a forward, followed at some point 
        * by a punch, in the case of hadouken, for example), in order of move priority (you will necessarily 
        * have input priority, where if 2 possible moves are input at the same time one will always come on 
        * top -- choosing the order well is important for a good interpreter).
        * 
        * If one is found, check if it's legal (there are plenty of reasons why you may not be able to use it right now 
        * -- you're in the middle of another move you can't cancel with this out of, in the air but input a ground move, etc),
        *  then you break out of the loop (you already know your move, since you searched in order of priority), and 
        *  then flush the buffer if this move type is set to flush the buffer (generally, special moves and above (supers etc) 
        *  will flush it, while command (forward+punch), normals (punch) and movement (forward) will not).
        * **/
        private Move MatchInputsToMoveList(ConsoleKey input)
        {
            Move resultingMove = null;
            List<Move> possibleMoves = Player.Character.MoveList
                .Where(w => w.Command.ActivatesOn == input)
                .OrderByDescending(o => o.Priority)
                .ToList();

            if(possibleMoves.Count > 0)
            {
                // Brute force approach for now...
                foreach(Move move in possibleMoves)
                {
                    if (IsMoveInBuffer(move))
                    {
                        resultingMove = move; 
                        if(move.FlushBuffer)
                        {
                            _buffer.Clear();
                        }                      
                        break;
                    }
                }
            }

            return resultingMove;
        }

        private bool IsMoveInBuffer(Move move)
        {
            int startingIndex = _buffer.Head;
            bool keepSearching = false;

            foreach(ConsoleKey key in move.Command.Commands)
            {
                keepSearching = false;
                for (int i = startingIndex; i != _buffer.Tail; i = _buffer.GetNextIndex(i))
                {
                    if(_buffer[i] == key)
                    {
                        startingIndex = _buffer.GetNextIndex(i);
                        keepSearching = true;
                        break;
                    }                    
                }               
                
                if (!keepSearching)
                {
                    return false;
                }                
            }           

            return true;   
        }
    }
}
