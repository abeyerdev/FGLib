using System;

namespace FGLib.InputHandling
{
    public static class InputMapperFactory
    {
        public static IInputMapper<T> CreateInputMapper<T>()
        {
            if (typeof(T) == typeof(ConsoleKey))
                return (IInputMapper<T>) new ConsoleKeyInputMapper();
            
                return null;
        }

    }
}
