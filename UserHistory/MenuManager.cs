using System;
using System.Collections;
using MelonLoader;
using UnityEngine;
using UnityEngine.UI;
using VRC.Core;
using VRChatUtilityKit.Ui;
using VRChatUtilityKit.Utilities;

namespace UserHistory
{
    public class MenuManager
    {
        private static int _playerIndex = 0;
        public static int PlayerIndex
        {
            get { return _playerIndex; }
            set
            {
                if (value > UserManager.cachedPlayers.Count - 1 || value < 0)
                    return;

                _playerIndex = value;

                pageNumLabel.TextComponent.text = $"<size=30>Page: {PageNum} of {LastPageNum}</size>";

                for (int i = 0; i < 12; i++)
                {

                    if (_playerIndex + i >= UserManager.cachedPlayers.Count)
                    {
                        buttons[i].TextComponent.text = "N/A";
                        buttons[i].Tooltip.field_Public_String_0 = "N/A";
                        buttons[i].ButtonComponent.onClick = new Button.ButtonClickedEvent();
                    }
                    else
                    {
                        UserManager.CachedPlayer player = UserManager.cachedPlayers[PlayerIndex + i];
                        buttons[i].TextComponent.text = $"{player.name}\n{player.timeJoined:G}";
                        buttons[i].Tooltip.field_Public_String_0 = $"User: {player.name} joined on {player.timeJoined:G}";
                        buttons[i].ButtonComponent.onClick = new Button.ButtonClickedEvent();
                        buttons[i].ButtonComponent.onClick.AddListener(new Action(() =>
                        {
                            if (player.user == null)
                                APIUser.FetchUser(player.id, new Action<APIUser>(OnUserReceived), null);
                            else
                                OnUserReceived(player.user);
                        }));
                    }
                }
            }
        }

        private static void OnUserReceived(APIUser user)
        {
            if (!Config.openInQuickMenu.Value)
            {
                UiManager.OpenBigMenu(false);
                UiManager.OpenUserInUserInfoPage(user.ToIUser());
            }
            else
            {
                UiManager.OpenUserInQuickMenu(user);
            }
        }
        // 
        public static int PageNum
        {
            get { return Mathf.CeilToInt((_playerIndex + 1) / 12f); }
        }
        public static int LastPageNum
        {
            get { return Mathf.CeilToInt(UserManager.cachedPlayers.Count / 12f); }
        }

        public static Transform openButton;
        public static SubMenu menu;
        private static readonly SingleButton[] buttons = new SingleButton[12];
        private static SingleButton pageUp;
        private static SingleButton pageDown;
        private static Label pageNumLabel;

        public static void UiInit()
        {
            UserHistoryMod.Instance.LoggerInstance.Msg("Loading UI...");

            menu = new SubMenu("UserHistoryMenu", "UserHistorySubMenu", "User History");

            openButton = UnityEngine.Object.Instantiate(UiManager.QMStateController.transform.Find("Container/Window/QMParent/Menu_Dashboard/Header_H1/RightItemContainer/Button_QM_Expand"));
            openButton.name = "UserHistory_UI";
            openButton.SetParent(UiManager.QMStateController.transform.Find("Container/Window/QMParent/"));
            openButton.localPosition = new Vector3(Config.openButtonX.Value, Config.openButtonY.Value, 0f);
            openButton.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
            openButton.GetComponent<Button>().onClick.AddListener(new Action(() => OpenUserHistoryMenu()));
            openButton.GetComponent<VRC.UI.Elements.Tooltips.UiTooltip>().field_Public_String_0 = "User History";
            openButton.GetComponentInChildren<Image>().overrideSprite = LoadAssets.MenuIcon;


            openButton.gameObject.SetActive(!(VRCUtils.IsUIXPresent && Config.useUIX.Value));
            Config.openButtonX.OnValueChanged += OnPositionChange;
            Config.openButtonY.OnValueChanged += OnPositionChange;

            MelonCoroutines.Start(WaitForQM());

            ButtonGroup buttgroup = null;
            var allButtons = new System.Collections.Generic.List<IButtonGroupElement>();
            int b = 0;
            for (int i = 1; i < 16; i++)
            {
                //MelonLogger.Msg($"i:{i}, b:{b}");
                switch (i)
                {
                    case 4: pageUp = new SingleButton(new Action(() => PlayerIndex -= 12), LoadAssets.UpArrow, "Go up a page", $"UpPageButton", "Go up a page", (butt) => allButtons.Add(butt)); break;
                    case 8: pageDown = new SingleButton(new Action(() => PlayerIndex += 12), LoadAssets.DownArrow, "Go down a page", $"DownPageButton", "Go down a page", (butt) => allButtons.Add(butt)); break;
                    case 12:
                        pageNumLabel = new Label($"Page: 1 of {LastPageNum}", "", "UserHistoryPageLabel", (butt) => allButtons.Add(butt));
                        pageNumLabel.gameObject.transform.Find("Text_H1").localPosition = new Vector3(0f, 40f, 0f); break;
                    case 16: new Label($"Blank", "subtext", "Blank", (butt) => allButtons.Add(butt)); break;
                    default:
                        buttons[b] = new SingleButton(null, LoadAssets.Item, "Placeholder", $"UserHistoryButton-{b}", "tooltip", (butt) => allButtons.Add(butt));
                        buttons[b].gameObject.transform.Find("Text_H4").localPosition = new Vector3(0f, -20f, 0f);
                        b++;
                        break;
                }
            }
            menu.AddButtonGroup(new ButtonGroup("InstanceHistoryButtons", "", allButtons, (group) => buttgroup = group));
            buttgroup.RemoveButtonHeader();


            /*
            pageUp = new SingleButton(menu.gameObject, GameObject.Find("UserInterface/QuickMenu/EmojiMenu/PageUp"), new Vector3(4, 0), "", new Action(() => PlayerIndex -= 9), $"Go up a page", "UpPageButton");
            pageDown = new SingleButton(menu.gameObject, GameObject.Find("UserInterface/QuickMenu/EmojiMenu/PageDown"), new Vector3(4, 2), "", new Action(() => PlayerIndex += 9), $"Go down a page", "DownPageButton");
            backButton = new SingleButton(menu.gameObject, new Vector3(4, 0), "Back", new Action(() => UiManager.OpenSubMenu("UserInterface/QuickMenu/ShortcutMenu")), "Press to go back to the Shortcut Menu", "BackButton", textColor: Color.yellow);
            backButton.gameObject.SetActive(false);
            pageNumLabel = new Label(menu.gameObject, new Vector3(4, 1), $"Page: 1 of {LastPageNum}", "PageNumberLabel");

            for (int i = 0; i < 9; i++)
                buttons[i] = new SingleButton(menu.gameObject, new Vector3((i % 3) + 1, Mathf.Floor(i / 3)), "Placeholder text", null, "Placeholder text", $"World Button {i + 1}", resize: true);*/

            if (VRCUtils.IsUIXPresent)
                typeof(UIXManager).GetMethod("AddOpenButtonToUIX").Invoke(null, null);

            UserHistoryMod.Instance.LoggerInstance.Msg("UI Loaded!");
        }

        public static IEnumerator WaitForQM()
        {
            //Wait for the QM to open before cloning the button onto the Dashboard/Launch Pad Menu. This is because VRCUK uses that menu as a basis for it's custom TabMenus
            while (GameObject.Find("/UserInterface/Canvas_QuickMenu(Clone)/Container/Window/MicButton") == null)
                yield return new WaitForSeconds(1f);
            openButton.SetParent(UiManager.QMStateController.transform.Find("Container/Window/QMParent/Menu_Here/QMHeader_H1"));
            openButton.localPosition = new Vector3(Config.openButtonX.Value, Config.openButtonY.Value, 0f); //300f, -60f
            UserHistoryMod.Instance.LoggerInstance.Msg("Initialized QM Button!");
        }

        public static void OpenUserHistoryMenu()
        {
            UiManager.OpenSubMenu(UiManager.QMStateController.field_Private_UIPage_0, menu.uiPage);
            PlayerIndex = 0;
        }

        private static void OnPositionChange(float oldValue, float newValue)
        {
            if (oldValue == newValue) return;

            openButton.gameObject.transform.localPosition = new Vector3(Config.openButtonX.Value, Config.openButtonY.Value);
        }
    }
}
