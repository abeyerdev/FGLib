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

        /// <summary>
        /// Map input on each raw input value and store as an integer 
        /// for the frame. Then store total frame input in the buffer.
        /// </summary>
        /// <param name="rawInputs"></param>
        public void ReceiveInputsForFrame(List<T> rawInputs)
        {
            List<int> frameInput = new List<int>();
            rawInputs.ForEach(rawInput => frameInput.Add(mapper.MapInput(rawInput)));
            var thing = frameInput;
            buffer.AddInput(finalInput);
        }
    }
}
