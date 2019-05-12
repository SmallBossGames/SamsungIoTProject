using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Utilities
{
    public static class Constants
    {
        public static readonly string currentRoomsStatusURL = "http://10.0.2.2:5000/api/roomslastinfo";
        public static readonly string currentRoomStatusURL = "http://10.0.2.2:5000/api/roomslastinfo/{0}";
        public static readonly string currentBoilerStatusURL = "http://10.0.2.2:5000/api/boilerlastinfo";
        public static readonly string quickInfoURL = "http://10.0.2.2:5000/api/QuickInfo";
        public static readonly string defaultUserName = "default";
    }
}
