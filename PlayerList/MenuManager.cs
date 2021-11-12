using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using MelonLoader;
using PlayerList.Config;
using PlayerList.Entries;
using PlayerList.Utilities;
using UnhollowerRuntimeLib;
using UnityEngine;
using UnityEngine.UI;
using VRChatUtilityKit.Components;
using VRChatUtilityKit.Ui;
using VRChatUtilityKit.Utilities;
using VRCSDK2;

namespace PlayerList
{
    public class MenuManager
    {
        public static List<SubMenu> playerListMenus = new List<SubMenu>();
        public static SubMenu sortMenu;
        public static ToggleButton menuToggleButton;

        public static bool shouldStayHidden;

        public static Label fontSizeLabel;

        public static GameObject playerList;
        public static RectTransform playerListRect;

        private static readonly Dictionary<EntrySortManager.SortType, SingleButton> sortTypeButtonTable = new Dictionary<EntrySortManager.SortType, SingleButton>();
        private static Image currentHighlightedSortType;
        private static PropertyInfo entryWrapperValue;

        public static void Init()
        {
            entryWrapperValue = PlayerListConfig.currentBaseSort.GetType().GetProperty("Value");
        }

        public static void ToggleMenu()
        {
            if (!playerListMenus.Any(subMenu => subMenu.gameObject.active) && !Constants.quickMenu.gameObject.active) return;
            menuToggleButton.ToggleComponent.isOn = shouldStayHidden;
            shouldStayHidden = !shouldStayHidden;
            if (playerListMenus.Any(subMenu => subMenu.gameObject.active) || Constants.quickMenu.gameObject.active) playerList.SetActive(!playerList.activeSelf);
        }

        public static void LoadAssetBundle()
        {
            // Stolen from UIExpansionKit (https://github.com/knah/VRCMods/blob/master/UIExpansionKit) #Imnotaskidiswear
            MelonLogger.Msg("Loading List UI...");
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("PlayerList.playerlistmod.assetbundle"))
            {
                using (var memoryStream = new MemoryStream((int)stream.Length))
                {
                    stream.CopyTo(memoryStream);
                    AssetBundle assetBundle = AssetBundle.LoadFromMemory_Internal(memoryStream.ToArray(), 0);
                    assetBundle.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                    playerList = UnityEngine.Object.Instantiate(assetBundle.LoadAsset_Internal("Assets/Prefabs/PlayerListMod.prefab", Il2CppType.Of<GameObject>()).Cast<GameObject>(), Constants.quickMenu.transform);
                }
            }

            playerList.SetLayerRecursive(12);
            playerList.AddComponent<VRC_UiShape>();
            playerListRect = playerList.GetComponent<RectTransform>();
            playerListRect.anchoredPosition = PlayerListConfig.playerListPosition.Value;
            playerListRect.localPosition = playerListRect.localPosition.SetZ(25); // Do this or else it looks off for whatever reason
            playerList.SetActive(false);

            shouldStayHidden = !PlayerListConfig.enabledOnStart.Value;

            Constants.playerListLayout = playerList.transform.Find("PlayerList Viewport/PlayerList").GetComponent<VerticalLayoutGroup>();
            Constants.generalInfoLayout = playerList.transform.Find("GeneralInfo Viewport/GeneralInfo").GetComponent<VerticalLayoutGroup>();
        }
        public static void AddMenuListeners()
        {
            // Add listeners
            if (PlayerListMod.HasUIX)
            {
                typeof(UIXManager).GetMethod("AddListenerToShortcutMenu").Invoke(null, new object[2]
                {
                    new Action(() => playerList.SetActive(!shouldStayHidden && !PlayerListConfig.onlyEnabledInConfig.Value)),
                    new Action(() => playerList.SetActive(false))
                });
            }
            else
            {
                EnableDisableListener shortcutMenuListener = Constants.quickMenu.gameObject.AddComponent<EnableDisableListener>();
                shortcutMenuListener.OnEnableEvent += new Action(() => playerList.SetActive(!shouldStayHidden && !PlayerListConfig.onlyEnabledInConfig.Value));
                shortcutMenuListener.OnDisableEvent += new Action(() => playerList.SetActive(false));
            }

            GameObject newElements = GameObject.Find("UserInterface/QuickMenu/QuickMenu_NewElements");
            GameObject Tabs = GameObject.Find("UserInterface/QuickMenu/QuickModeTabs");

            UiManager.OnQuickMenuClosed += new Action(PlayerListConfig.SaveEntries);

            EnableDisableListener playerListMenuListener = playerListMenus[0].gameObject.AddComponent<EnableDisableListener>();
            playerListMenuListener.OnEnableEvent += new Action(() =>
            {
                playerList.SetActive(!shouldStayHidden);
                playerListRect.anchoredPosition = Converters.ConvertToUnityUnits(new Vector3(2.5f, 3.5f));
                newElements.SetActive(false);
            });
            playerListMenuListener.OnDisableEvent += new Action(() =>
            {
                playerList.SetActive(false);
                playerListRect.anchoredPosition = PlayerListConfig.playerListPosition.Value;
                playerListRect.localPosition = playerListRect.localPosition.SetZ(25);
                newElements.SetActive(true);
            });
        }

        public static void AddPlayerListToSubMenu(SubMenu menu)
        {
            EnableDisableListener subMenuListener;
            subMenuListener = menu.gameObject.GetComponent<EnableDisableListener>();
            if (subMenuListener == null)
                subMenuListener = menu.gameObject.AddComponent<EnableDisableListener>();
            subMenuListener.OnEnableEvent += new Action(() =>
            {
                playerList.SetActive(!shouldStayHidden);
                playerListRect.anchoredPosition = Converters.ConvertToUnityUnits(new Vector3(6.5f, 3.5f));
            });
            subMenuListener.OnDisableEvent += new Action(() =>
            {
                playerList.SetActive(false);
                playerListRect.anchoredPosition = PlayerListConfig.playerListPosition.Value;
                playerListRect.localPosition = playerListRect.localPosition.SetZ(25);
            });
        }
        public enum MenuButtonPositionEnum
        {
            TopRight,
            TopLeft,
            BottomLeft,
            BottomRight
        }
    }
}
