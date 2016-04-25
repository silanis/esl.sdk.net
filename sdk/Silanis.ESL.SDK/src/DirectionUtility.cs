using System;

namespace Silanis.ESL.SDK
{
    public class DirectionUtility
    {
        public static string getDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.ASCENDING:
                    return "asc";
                case Direction.DESCENDING:
                    return "desc";
                default:
                    throw new EslException("Could not return string version of Direction enum", null);
            }
        }
    }
}

