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

        // Map input on each raw input value and store as an integer 
        // for the frame. Then store total frame input in the buffer.
        public void ReceiveInputsForFrame(List<T> rawInputs)
        {
            List<int> frameInput = new List<int>();
                        
            foreach(T rawInput in rawInputs)
            {
                frameInput.Add(mapper.MapInput(rawInput));
            }

            Input finalInput = Input.ParseBits(frameInput);
            buffer.AddInput(finalInput);
        }
    }
}
