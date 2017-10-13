

namespace FGLib
{
    public class PlayerInfo
    {
        public Character Character { get; }
        public int PlayerNumber { get; }

        public PlayerInfo(int playerNumber, Character character)
        {
            PlayerNumber = playerNumber;
            Character = character;
        }
    }
}
