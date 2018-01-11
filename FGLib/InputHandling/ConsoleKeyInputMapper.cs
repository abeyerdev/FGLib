using System;

namespace FGLib.InputHandling
{
    public class ConsoleKeyInputMapper : IInputMapper<ConsoleKey>
    {
        public int MapInput(ConsoleKey input)
        {
            switch (input)
            {
                case ConsoleKey.DownArrow:
                    return 1 << (int)InputBitFlagsEnum.Down;
                case ConsoleKey.LeftArrow:
                    return 1 << (int)InputBitFlagsEnum.Left;
                case ConsoleKey.UpArrow:
                    return 1 << (int)InputBitFlagsEnum.Up;
                case ConsoleKey.RightArrow:
                    return 1 << (int)InputBitFlagsEnum.Right;
                case ConsoleKey.NumPad1:
                    return 1 << (int)InputBitFlagsEnum.LightKick;
                case ConsoleKey.NumPad2:
                    return 1 << (int)InputBitFlagsEnum.MediumKick;
                case ConsoleKey.NumPad3:
                    return 1 << (int)InputBitFlagsEnum.HeavyKick;
                case ConsoleKey.NumPad4:
                    return 1 << (int)InputBitFlagsEnum.LightPunch;
                case ConsoleKey.NumPad5:
                    return 1 << (int)InputBitFlagsEnum.MediumPunch;
                case ConsoleKey.NumPad6:
                    return 1 << (int)InputBitFlagsEnum.HeavyPunch;
                default:
                    return (int)InputBitFlagsEnum.Undefined;
            }
        }
    }
}
