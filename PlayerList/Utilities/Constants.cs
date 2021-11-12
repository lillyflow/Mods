using UnityEngine;
using UnityEngine.UI;

namespace PlayerList.Utilities
{
    public class Constants
    {
        public static GameObject quickMenu;
        public static VerticalLayoutGroup playerListLayout;
        public static VerticalLayoutGroup generalInfoLayout;
        public static Vector2 quickMenuColliderSize = new Vector2(1, 1);

        public static void UIInit()
        {
            quickMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)").gameObject;
        }

        public static void OnSceneWasLoaded()
        {
            //if (quickMenuColliderSize != null)
            //    quickMenuColliderSize = quickMenu.GetComponent<BoxCollider>().size;
        }
    }
}
