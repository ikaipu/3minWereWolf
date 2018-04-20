using System;

namespace Script
{
    public enum PlayerId
    {
        Player1 = 1,
        Player2 = 2,
        Player3 = 3,
        Player4 = 4,
        Player5 = 5,
        Player6 = 6,
    }
    
    static class PlayerIdExtensions
    {
        public static string ToName(this PlayerId id)
        {
            switch (id)
            {
                case PlayerId.Player1:
                    return "1P";
                case PlayerId.Player2:
                    return "2P";
                case PlayerId.Player3:
                    return "3P";
                case PlayerId.Player4:
                    return "4P";
                case PlayerId.Player5:
                    return "5P";
                case PlayerId.Player6:
                    return "6P";
                default:
                    return "???";
            }
        }

        public static PlayerId FromInt(int i)
        {
            return (PlayerId)Enum.ToObject(typeof(PlayerId), i);
        }

        public static int ToInt(PlayerId playerId)
        {
            return (int) playerId;
        }
    }
}