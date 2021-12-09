using MelonLoader;
using VRChatUtilityKit.Utilities;

namespace UserHistory
{
    public class Config
    {
        public static MelonPreferences_Category category;
        public static MelonPreferences_Entry<bool> useUIX;
        public static MelonPreferences_Entry<float> openButtonX;
        public static MelonPreferences_Entry<float> openButtonY;
        public static MelonPreferences_Entry<bool> openInQuickMenu;

        public static void Init()
        {
            category = MelonPreferences.CreateCategory("UserHistory Config");
            useUIX = category.CreateEntry(nameof(useUIX), false, "Should use UIX instead of regular buttons", null, !VRCUtils.IsUIXPresent);
            openButtonX = category.CreateEntry(nameof(openButtonX), 300f, "X position of button. Does not apply when using UIX.");
            openButtonY = category.CreateEntry(nameof(openButtonY), -60f, "Y position of button. Does not apply when using UIX.");
            openInQuickMenu = category.CreateEntry(nameof(openInQuickMenu), true, "Should open the selected user in the QuickMenu\ninstead of big menu", null);
        }
    }
}
