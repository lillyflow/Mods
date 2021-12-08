# Sleepers VRC Mods<!-- omit in toc -->

These are mods that weren't being maintained anymore, gathered together. So that hopefully as a community we can still maintain them.

This repository was forked from Loukylor's mods after he stopped maintaining them.
As they do a lot of good maintaining them was found to be important enough that this repo was created.

The intention of the name change is to make it clear that this project hopes to have multiple people maintaining it instead of just a single person burning themselves out with the burden - Make sure to get enough sleep y'all modders!

## Disclaimer<!-- omit in toc -->

VRChat does **not** condone the use of mods, and, if found to be modifying the client, then you **will** be punished.

That being said, there is no anticheat of any sort in the client as of writing this.
There is an API limiter & Photon checks, and the mods listed in this repository avoid triggering those.
The real only way to get punished on this game is to piss of the aforementioned checks, or be reported by a user with evidence of you using a mod.

**These mods are provided as-is without any warranty and we will not be held responsible for anything that using mods may cause**.

## Installation<!-- omit in toc -->

1. Follow the instructions on the [MelonLoader wiki](https://melonwiki.xyz/#/) on installing MelonLoader (MelonLoader is the mod loader which will allow the mods to run).
2. Download the mod(s) you would like to install.
3. Drag'n'drop the downloaded mod(s) into the `Mods` folder in the `VRChat` folder.

More detailed instructions and more mods can be found in the [VRChat Modding Group Discord](https://discord.gg/rCqKSvR).

## Table of contents<!-- omit in toc -->

- [AskToPortal](#asktoportal)
- [AvatarHider](#avatarhider)
- [ChairExitController](#chairexitcontroller)
- [CloningBeGone](#cloningbegone)
- [InstanceHistory](#instancehistory)
- [PlayerList](#playerlist)
- [PreviewScroller](#previewscroller)
- [PrivateInstanceIcon](#privateinstanceicon)
- [ReloadAvatars](#reloadavatars)
- [RememberMe](#rememberme)
- [SelectYourself](#selectyourself)
- [TriggerESP](#triggeresp)
- [UserHistory](#userhistory)
- [UserInfoExtensions](#userinfoextensions)
- [VRChatUtilityKit](#vrchatutilitykit)
  - [For Developers](#for-developers)
  - [Licensing](#licensing)
- [Credits](#credits)

## AskToPortal

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

A mod that makes sure you want to enter a portal, every time you enter a portal

This mod also contains many checks for portal droppers, or people who use a mod that drops portals maliciously.
If the mod detects a portal dropper, it will give you the option of blacklisting the user until you restart your game.

You can also toggle the mod on and off and auto accept portals from friends, yourself, and one's placed in the world itself (by the creator).

![Basic User Prompt](https://i.imgur.com/IiOnkCM.png)
![Detailed User Prompt](https://i.imgur.com/N4QHlbb.png)
![Basic User Prompt with Errors](https://i.imgur.com/fja7qNY.png)
![Detailed User Prompt with Errors](https://i.imgur.com/SJPALdl.png)

## AvatarHider

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

This mod will automatically hide avatars based on the distance away from you.
There's no real reason to render avatars that you don't even pay attention to, right?

For the best experience, it is recommended to run this mod with UIExpansionKit.
"Hide Distance" is customizable and can be changed in meters (default is 7 meters).
Friend's avatars are ignored by default, but can be hidden by distance too if needed.
"Exclude Shown Avatars" will ignore to hide a persons avatar if you are showing the avatar.
"Disable Spawn Sounds" will only prevent a spawn sound from replaying when the avatar becomes visable again.

Tip:
If a friend is using an unoptimized avatar and you would like AvatarHider to hide it, disable "Ignore Friends" and enable "Exclude Shown Avatars".
Then show your friends avatars that you would like to be ignored by AvatarHider.
And set the friend with the unoptimized avatar to the "Use Safety Settings" in the QuickMenu.

## ChairExitController

Prevents you from falling out of chairs accidentally.
Press both triggers in VR, or q and e in desktop to leave chairs.

## CloningBeGone

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

Turns off cloning when you join an instance.

You can configure whether you want cloning to be on or off based off instance type.
So for example, you can have cloning on in Invite+ worlds and off in all the other instance types.

You can also disable/enable cloning for a specific avatar. The buttons to control these can be toggled on and off.
Keep in mind however, that this requires the use of UIX and will overwrite the instance type cloning.

## InstanceHistory

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

A basic instance history mod

It has an optinal dependency for UIX when opening the instance history menu. This means you can run with or without it.
It is highly recommnded to use UIX because it's just easier, although there are preferences to change the position of the regular button if you don't like UIX.

## PlayerList

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

Adds a player list to the ShortcutMenu

Each entry to the player list is a button that will open the user in the QuickMenu on click.
The player's name will be colored to the rank they are (OGTrustRanks compatible!), each entry also has the player's ping, fps, platform, avatar performance, distance from you, and number of owned objects.
Note that the number of owned objects will be inaccurate in instances where you're alone and also when you first join an instance.
You may also toggle each of these on and off.
So, if you don't like how the avatar performance takes up space, you can turn it off.

Note: distance from you will be disabled in worlds that do not allow risky functions.

There is also a list of info about the game and world you are in.
It lists:

- Time since joining the instance (Room Time)
- System time in 12hr format and 24hr format
- Game build number (Game Version)
- Position in world (Coordinate Position)
- World Name
- World Author Name
- Instance Master (The person who get the host glitch)
- Instance Creator (The person who has moderation powers in the instance, only applicable to non-public instances)
- Whether risky functions are allowed or not.

And Each of these can be individually toggled on or off.

Now for more customizable things, you can change fontsize, the list's position (the QuickMenu hitbox will scale automatically), and the PlayerList button position.
You can also change the color of the name, so instead of showing trust and friends, you could show friends only, or trust only, or just none.
The list can also be numbered, or ticked and can be condensed so more stuff fits on one line.

The list may also be turned off on startup, and can always be toggled on using `left ctrl + f1`

![Picture of the List](https://i.imgur.com/jvfytTc.png)

## PreviewScroller

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

A mod that let's you sort of scroll the avatar preview so you can control where it's facing

![GIF of the Scrolling in Action](https://i.imgur.com/D2JVwnD.mp4)

## PrivateInstanceIcon

Adds an icon to the social menu that shows if you can join a person or not.

Let's you configure what the mod does when a user is in a certain world type.
There are 3 things the mods does:

- Hides the user from the list
- Shows an icon indicating what world type they're in
- Acts like default VRChat

Each of these behaviors can be applied to users in:

- Private worlds
- Private worlds that you can join. (Join me but in private)
- Friends only worlds
- Friends plus worlds
- Public worlds

You can also configure the mod to not affect the favorite users lists.

![Picture of me with the icon on it](https://i.imgur.com/T0Z0uba.png)

## ReloadAvatars

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]
[![Requires UIExpansionKit][UIExBadge]][UIExLink]

Adds buttons to reload a single user's avatar or all users' avatar.

The buttons can each be toggled on and off using UIX

## RememberMe

Mod for VRChat using MelonLoader

Adds a "Remember Me" check-box to the Login screen.
When "Remember Me" is checked off it will auto-fill the last saved VRChat Credentials.

## SelectYourself

[![Requires UIExpansionKit][UIExBadge]][UIExLink]

Adds a button that allows you to select yourself

The button can be toggled on and off using UIX

## TriggerESP

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]
[![Requires UIExpansionKit][UIExBadge]][UIExLink]

A trigger ESP that will highlight all VRChat interactables as well as any Unity UI buttons.

The color the ESP is customizable, and you can also set the color as random.
The strength of the ESP is customizable as well.

Note that it disables itself in worlds that don't allow risky functions.

![Picture of Outline](https://i.imgur.com/QnawlKb.jpg)
![Picture of Wireframe](https://i.imgur.com/nnTN4na.jpg)

## UserHistory

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]

A mod that shows you when a user joined, and when clicking on them, opens when in the user page.
It's basically a copy + paste of [InstanceHistory](#instancehistory)

It has an optinal dependency for UIX when opening the user history menu. This means you can run with or without it.
It is highly recommnded to use UIX because it's just easier, although there are preferences to change the position of the regular button if you don't like UIX.

## UserInfoExtensions

[![Requires VRChatUtilityKit][VRCUKBadge]][VRCUKLink]
[![Requires UIExpansionKit][UIExBadge]][UIExLink]

A mod that adds buttons to the to make VRChat more convenient

Adding individually toggleable buttons that allow you to:

- Select a user in the Quick Menu from the Social Menu page.
- Find the avatar's author from the Social Menu and Avatar Menu pages.
- Open the links the selected user has in their bio.
- Display the languages the selected user has in their bio.

The buttons can always be accessed in a popup attached to the User Details Page.

Additionally, in the popup you can see the user's:

- username (what the person logs in with)
- platform (Quest or PC)
- last login (literal login, not starting the game)
- date joined (date original unmerged account created)
- friend number (the number friend they are. like 1st friend, 2nd friend, etc.)

For avatars, you can see their:

- author's name
- name
- supported platforms
- release type
- time which they were last updated
- version

## VRChatUtilityKit

Various sets of utilites for developers to use in their mods.

### For Developers

If you wish to use this mod, please respect the license, LGPL v3. You can read more below.
The source is documented, and the XML file is included in the release.
To utilise the XML file, just put it in the same directory as the copy of the utility kit you are referencing.

### Licensing

This library is licensed under LGPL v3.
This means that you are allowed to reference the library in your code as long as you disclose source and have a license and copyright notice you will be fine.
In the case that you would like to modify or include the library in your mod, you must use the same license as well as state any changes.

We will seek to punish license violations.

There is some code that was originally licensed under GPL v3, however express permission has been granted to license said code under LGPL v3.

## Credits

This is by no means everyone, but some attribution is better than none:

- [Loukylor](https://github.com/loukylor) for a lot of things, as these mods were originally by them.
- [knah](https://github.com/knah) for [Join Notifier's](https://github.com/knah/VRCMods) join/leave and asynchronous utilities.
- [DubyaDude](https://github.com/DubyaDude) for [RubyButtonAPI](https://github.com/DubyaDude/RubyButtonAPI) as reference for the button API.
- [Psychloor](https://github.com/Psychloor) for the risky functions check.
- [Brycey92](https://github.com/Brycey92) for AvatarHider contributions.
- [dave-kun](https://github.com/dave-kun) for RememberMe & AvatarHider Contributions.
- [ImTiara](https://github.com/ImTiara) for the original version of AvatarHider
- [KortyBoi](https://github.com/KortyBoi) for PlayerList's layout & help with getting some of the information.
- Frostbyte for PlayerList optimization help
- [HerpDerpinstine](https://github.com/HerpDerpinstine) for being the original author of RememberMe
- [neitri](https://github.com/netri) for the ["Distance Face Outline" shader](https://github.com/netri/Neitri-Unity-Shaders) that was modified to create the TriggerESP shader.
- Potato for PreviewScroller contributions.
- [Sarayalth](https://github.com/Sarayalth) for VRCUtilityKit contributions.
- [ljoonal](https://github.com/ljoonal) for various tiny modifications & cleanup/management work.
- [Nirv](https://github.com/Nirv-git) for InstanceHistory (& UserHistory) contributions that have been merged from [their repository](https://github.com/Nirv-git/VRC-Mods).
- [Adnezz](https://github.com/Adnezz) for PlayerHistory contributions that have been merged from [their repository](https://github.com/Adnezz/PlayerList)

If you feel like the list is missing someone, do create a PR!

[VRCUKBadge]: https://img.shields.io/badge/VRCUK-Required-informational?style=flat
[VRCUKLink]: https://github.com/SleepyVRC/Mods/releases
[UIExBadge]: https://img.shields.io/badge/UIEx-Required-informational?style=flat
[UIExLink]: https://github.com/knah/VRCMods/
