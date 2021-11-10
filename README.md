# To Do
Cleanup this ReadMe

# Disclaimer!!!
VRChat does **not** condone the use of mods, and, if found to be modifying the client, then you **will** be punished.

**That being said,** there is no anticheat of any sort (file integrity check, position check, etc.) placed on the client.
The only anticheat (if it could be called that) in VRChat is an API limiter, and Photon checks, and the mods listed in this repository, will not trigger any of those.
The real only way to get punished on this game is to piss of the aforementioned anticheats, or be reported by a user with video evidence of you using a mod (whether this be you flying or verbally admitting you mod the game).

So just, stay safe, and don't be stupid and run around saying you use mods, and you'll be a-ok.

Also, for my sake, **I am not responsible for any bans using my mods may cause**. 
I do my abselute best to make sure none of my mods, verified or unverified, will increase your chance of getting banned by any amount.
And in fact, only one of my mods could trigger any anticheat in any way (UserInfoExtensions), but there are limits in place that completely prevent this.
**But**, no matter how small, there is always a chance. 

# Installation 
1. Simply follow the instructions on the [MelonLoader wiki](https://melonwiki.xyz/#/) on installing MelonLoader **0.4.0** (MelonLoader is the mod loader which will allow my mods to run). 
2. Make sure you've installed version 0.4.0, as 0.2.7.4 will not function with VRChat.
3. Then download the mod(s) you would like to install from the [releases](https://github.com/loukylor/VRC-Mods/releases) section of this repository.
4. Allow the game to run once (this will set up a bunch of things MelonLoader uses)
5. And finally, drag and drop the downloaded mod(s) into the newly created `Mods` folder in the `VRChat` folder and restart the game.
More detailed instructions and more mods can be found in the [VRChat Modding Group Discord](https://discord.gg/rCqKSvR).

# InstanceHistory
A basic instance history mod

## Features
It has an optinal dependency for UIX when opening the instance history menu. This means you can run with or without it.
It is highly recommnded to use UIX because it's just easier, although there are preferences to change the position of the regular button if you don't like UIX.

![image](https://user-images.githubusercontent.com/81605232/141090579-b46a653a-1f8b-4cc2-842d-fecbd7208eec.png)


## Requirements
 - [VRChatUtilityKit](https://github.com/loukylor/VRC-Mods/releases)


## For Developers
If you wish to use this mod, please respect the license, LGPL v3. You can read more below.
The source is documented, and the XML file is included in the release.
To utilise the XML file, just put it in the same directory as the copy of the utility kit you are referencing.

## Licensing
This library is licensed under LGPL v3.
This means that you are allowed to reference the library in your code as long as you disclose source and have a license and copyright notice you will be fine.
In the case that you would like to modify or include the library in your mod, you must use the same license as well as state any changes.

If you are caught not properly following the license, I will not hesitate to take you repo or Discord account down.

Also note that I have used code licensed under GPL v3, however, I have been granted express permission to license this code under LGPL v3.

# Credits
- [knah](https://github.com/knah) as I use [Join Notifier's](https://github.com/knah/VRCMods) join/leave and asynchronous utilities.
- [DubyaDude](https://github.com/DubyaDude) as I used [RubyButtonAPI](https://github.com/DubyaDude/RubyButtonAPI) as reference for my button API.
- [Psychloor](https://github.com/Psychloor) as I used his code as a template for my risky functions check.