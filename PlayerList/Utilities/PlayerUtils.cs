using VRC;
using VRC.DataModel;

namespace PlayerList.Utilities
{
    public static class PlayerUtils
    {
        public static string GetPlatform(Player player)
        {
            if (player.prop_APIUser_0.last_platform == "standalonewindows")
                if (player.prop_VRCPlayerApi_0.IsUserInVR())
                    return "VR".PadRight(2);
                else
                    return "PC".PadRight(2);
            else
                return "Q".PadRight(2);
        }

        public static string GetPingColor(int ping)
        {
            if (ping <= 75)
                return "#00ff00";
            else if (ping > 75 && ping <= 125)
                return "#008000";
            else if (ping > 125 && ping <= 175)
                return "#ffff00";
            else if (ping > 175 && ping <= 225)
                return "#ffa500";
            else
                return "#ff0000";
        }
        public static string GetFpsColor(int fps)
        {
            if (fps >= 60)
                return "#00ff00";
            else if (fps < 60 && fps >= 45)
                return "#008000";
            else if (fps < 45 && fps >= 30)
                return "#ffff00";
            else if (fps < 30 && fps >= 15)
                return "#ffa500";
            else
                return "#ff0000";
        }
        public static string ParsePerformanceText(AvatarPerformanceRating rating)
        {
            switch (rating)
            {
                case AvatarPerformanceRating.VeryPoor:
                    return "Awful";
                case AvatarPerformanceRating.Poor:
                    return "Poor".PadRight(5);
                case AvatarPerformanceRating.Medium:
                    return "Med".PadRight(5);
                case AvatarPerformanceRating.Good:
                    return "Good".PadRight(5);
                case AvatarPerformanceRating.Excellent:
                    return "Great";
                case AvatarPerformanceRating.None:
                    return "?¿?¿?";
                default:
                    return rating.ToString().PadRight(5);
            }
        }
    }
}
