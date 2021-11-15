using MelonLoader;
using UnityEngine;
using UnityEngine.UI;

namespace PlayerList.Utilities
{
    public class Constants
    {
        public static GameObject shortcutMenu;
        public static GameObject quickMenu;
        public static Sprite checkSprite;
        public static Sprite blankSprite;
        public static VerticalLayoutGroup playerListLayout;
        public static VerticalLayoutGroup generalInfoLayout;
        public static Vector2 quickMenuColliderSize;

        public static void UIInit()
        {
            shortcutMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Dashboard").gameObject;
            quickMenu = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window").gameObject;
            //Texture2D source = 
            checkSprite = GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Modal_AddWorldToPlaylist/MenuPanel/ScrollRect/Viewport/VerticalLayoutGroup/Cell_QM_WorldPlaylistToggle 1/ButtonElement_CheckBox/Checkmark").GetComponent<Image>().activeSprite;
            blankSprite = Sprite.Create(new Rect(0, 0, 64, 64), new Vector2(2, 2), 100);
            //MelonLogger.Msg(source.name);
            //MelonLogger.Msg(GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Menu_Notifications/Panel_NoNotifications_Message/Icon").GetComponent<Image>().activeSprite.texture.name);
            //checkSprite = Sprite.Create(new Rect(0f, 0f, 64f, 64f), new Vector2(0.5f, 0.5f), 100, source); //0f, 2060f, 256f, 256f
            //checkSprite = //GameObject.Find("UserInterface").transform.Find("Canvas_QuickMenu(Clone)/Container/Window/QMParent/Modal_ConfirmDialog/MenuPanel/Buttons/Button_Yes/Background_Button").GetComponent<Image>().activeSprite;

            //GameObject.Find("UserInterface/Canvas_QuickMenu(Clone)/Container/Window/QMParent/");//QuickMenu.prop_QuickMenu_0.gameObject;
            //UnityUtils.
        }

        public static void OnSceneWasLoaded()
        {
            if (quickMenuColliderSize != null)
                quickMenuColliderSize = quickMenu.GetComponent<BoxCollider>().size;
        }
    }
}
