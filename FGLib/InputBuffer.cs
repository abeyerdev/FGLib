

namespace FGLib
{
    /// <summary>
    /// Provides functionality for controlling the resolution
    /// of player inputs.
    /// </summary>
    public class InputBuffer
    {
        private const int DEFAULT_BUFFER_SIZE = 60;
        private CircularQueue<string> _buffer;
        
        public InputBuffer()
        {
            _buffer = new CircularQueue<string>(DEFAULT_BUFFER_SIZE);
        }

        public InputBuffer(int bufferSize)
        {
            _buffer = new CircularQueue<string>(bufferSize);
        }

        public Move AddInput(string input)
        {
            _buffer.Add(input);
            return MatchInputsToMoveList();
        }

        private Move MatchInputsToMoveList()
        {
            Move resultingMove = null;

            return resultingMove;
        }
    }
}
