using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utilities
{
    public static class Constants
    {
        public static readonly string currentRoomsStatusURL = "https://localhost:44330/api/roomslastinfo";
        public static readonly string currentRoomStatusURL = "https://localhost:44330/api/roomslastinfo/{0}";
        public static readonly string currentBoilerStatusURL = "https://localhost:44330/api/boilerlastinfo";
        public static readonly string defaultUserName = "default";
    }
}
