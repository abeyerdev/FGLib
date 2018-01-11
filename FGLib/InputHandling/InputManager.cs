using System;
using System.Collections.Generic;

namespace FGLib.InputHandling
{
    public class InputManager<T>
    {
        InputBuffer buffer;
        IInputMapper<T> mapper;

        public InputManager()
        {
            buffer = new InputBuffer();
            mapper = InputMapperFactory.CreateInputMapper<T>();
        }

        public void ReceiveInputsForFrame(List<T> rawInputs)
        {
            // Will utilize mapper.MapInput() on each input value
            // and store as an integer for the frame. This will then need to
            // go into the buffer.

        }
    }
}
