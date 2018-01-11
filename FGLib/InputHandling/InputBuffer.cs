using System;
using System.Collections.Generic;
using System.Linq;

namespace FGLib.InputHandling
{
    /// <summary>
    /// Provides functionality for controlling the resolution
    /// of player inputs.
    /// </summary>
    public class InputBuffer
    {
        const int DEFAULT_BUFFER_SIZE = 120;
        readonly CircularQueue<Input> buffer;

        public PlayerInfo Player { get; }
        public int Size { get { return buffer.Size; } }

        public InputBuffer() 
        {
            buffer = new CircularQueue<Input>(DEFAULT_BUFFER_SIZE);
        }

        public InputBuffer(PlayerInfo player, int bufferSize = DEFAULT_BUFFER_SIZE)
        {
            buffer = new CircularQueue<Input>(bufferSize);
            Player = player;
        }

        public void AddInput(Input input)
        {
            buffer.Add(input);
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
        public Move ResolveInput()
        {
            return null;
        }

        Move matchInputsToMoveList(Input input)
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
                    if (isMoveInBuffer(move))
                    {
                        resultingMove = move; 
                        if(move.FlushBuffer)
                        {
                            buffer.Clear();
                        }                      
                        break;
                    }
                }
            }

            return resultingMove;
        }

        bool isMoveInBuffer(Move move)
        {
            int startingIndex = buffer.Head;
            bool keepSearching = false;

            foreach(Input key in move.Command.Commands)
            {
                keepSearching = false;
                for (int i = startingIndex; i != buffer.Tail; i = buffer.GetNextIndex(i))
                {
                    if(buffer[i] == key)
                    {
                        startingIndex = buffer.GetNextIndex(i);
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
