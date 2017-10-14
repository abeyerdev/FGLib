using System;
using FGLib;
using FGLib.CharacterData;

namespace FGLibDriver
{
    class Program
    {
        static void Main(string[] args)
        {
            Character character = new Character("Ryu", Ryu.GetMoveList());
            PlayerInfo player = new PlayerInfo(1, character);
            InputBuffer inputBuffer = new InputBuffer(player);
            Move executedMove;

            Console.WriteLine("Input key commands to execute moves. Press Enter to quit.");

            ConsoleKey keyPressed = Console.ReadKey().Key;
            while (keyPressed != ConsoleKey.Enter)
            {
                executedMove = inputBuffer.AddAndResolveInput(keyPressed);

                if(executedMove != null)
                {
                    Console.WriteLine(string.Format("{0}{1} executed!", Environment.NewLine, executedMove.Name));
                }

                keyPressed = Console.ReadKey().Key;
            }            
        }
    }
}
