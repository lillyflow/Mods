using MelonLoader;

namespace InstanceHistory
{
    class Config
    {
        public static MelonPreferences_Category category;
        public static MelonPreferences_Entry<bool> useUIX;
        public static MelonPreferences_Entry<float> openButtonX;
        public static MelonPreferences_Entry<float> openButtonY;

        public static void Init()
        {
            category = MelonPreferences.CreateCategory("InstanceHistory Config");
            useUIX = category.CreateEntry(nameof(useUIX), false, "Should use UIX instead of regular buttons", null, !InstanceHistoryMod.HasUIX);
            openButtonX = category.CreateEntry(nameof(openButtonX) + "_", 200f, "X position of button. Does not apply when using UIX.");
            openButtonY = category.CreateEntry(nameof(openButtonY) + "_", -60f, "Y position of button. Does not apply when using UIX.");
        }
    }
}
