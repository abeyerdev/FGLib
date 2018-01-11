using System;

namespace FGLib.InputHandling
{
    public enum InputBitFlagsEnum
    {
        Neutral = 0,
        Down = 1,
        Left = 2,
        Up = 3,
        Right = 4,
        LightPunch = 5,
        MediumPunch = 6,
        HeavyPunch = 7,
        LightKick = 8,
        MediumKick = 9,
        HeavyKick = 10,
        Undefined = int.MaxValue
    }
}
