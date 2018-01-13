using System;
using System.Collections.Generic;

namespace FGLib.InputHandling
{
    /// <summary>
    /// Class that handles inputs as normalized collections of bit flags.
    /// </summary>
    public class Input
    {
        List<InputEnum> inputs;

        /// <summary>
        /// Create an Input object for a given frame of input values.
        /// NOTE: It is assumed this is called on a per-frame basis!
        /// This means that order cannot be ensured if it is called
        /// with an input bit collection that encompasses more than 
        /// a single frame!
        /// </summary>
        /// <param name="frameInputs"></param>
        public Input(int frameInputs)
        {
            inputs = new List<InputEnum>();
            AssignInputs(frameInputs);            
        }

        public override string ToString()
        {
            string result = "";
            foreach(InputEnum input in inputs)
            {
                result += input.ToString() + ", ";
            }
            return result;
        }

        private void AssignInputs(int frameInputs)
        {
            string value = Convert.ToString(frameInputs, 2);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.Neutral) == 1 << (int)InputBitFlagsEnum.Neutral)
                inputs.Add(InputEnum.Neutral);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.Down) == 1 << (int)InputBitFlagsEnum.Down)
                inputs.Add(InputEnum.Down);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.Left) == 1 << (int)InputBitFlagsEnum.Left)
                inputs.Add(InputEnum.Left);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.Up) == 1 << (int)InputBitFlagsEnum.Up)
                inputs.Add(InputEnum.Up);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.Right) == 1 << (int)InputBitFlagsEnum.Right)
                inputs.Add(InputEnum.Right);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.LightPunch) == 1 << (int)InputBitFlagsEnum.LightPunch)
                inputs.Add(InputEnum.LightPunch);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.MediumPunch) == 1 << (int)InputBitFlagsEnum.MediumPunch)
                inputs.Add(InputEnum.MediumPunch);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.HeavyPunch) == 1 << (int)InputBitFlagsEnum.HeavyPunch)
                inputs.Add(InputEnum.HeavyPunch);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.LightKick) == 1 << (int)InputBitFlagsEnum.LightKick)
                inputs.Add(InputEnum.LightKick);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.MediumKick) == 1 << (int)InputBitFlagsEnum.MediumKick)
                inputs.Add(InputEnum.MediumKick);
            if ((frameInputs & 1 << (int)InputBitFlagsEnum.HeavyKick) == 1 << (int)InputBitFlagsEnum.HeavyKick)
                inputs.Add(InputEnum.HeavyKick);
        }

        // Go through each int bit value and return an Input object.
        // We use bitwise OR to flip relevant input flags for our final value.
        internal static Input ParseBits(List<int> frameInputs)
        {
            int frameInput = 0;
            frameInputs.ForEach(input => frameInput = frameInput | input);

            return new Input(frameInput);
        }
    }
}
