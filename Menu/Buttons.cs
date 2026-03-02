using StupidTemplate.Classes;
using StupidTemplate.Mods;
using static StupidTemplate.Menu.Main;
using static StupidTemplate.Settings;

namespace StupidTemplate.Menu
{
    public class Buttons
    {
        public static ButtonInfo[][] buttons = new ButtonInfo[][]
        {
            new ButtonInfo[] { // Main Mods [0]
                new ButtonInfo { buttonText = "Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Opens the main settings page for the menu."},

                new ButtonInfo { buttonText = "Room Mods", method =() => currentCategory = 5, isTogglable = false, toolTip = "Opens the room mods tab."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => currentCategory = 6, isTogglable = false, toolTip = "Opens the movement mods tab."},
                new ButtonInfo { buttonText = "Safety Mods", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens the safety mods tab."},
                new ButtonInfo { buttonText = "Fun/Challenge Mods", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens the Fun/Challenge mods tab."},
                new ButtonInfo { buttonText = "Nametags Mods", method =() => currentCategory = 9, isTogglable = false, toolTip = "Opens the Nametags mods tab."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Menu Settings", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement Settings", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu."},
                new ButtonInfo { buttonText = "Nametags Settings", method =() => currentCategory = 4, isTogglable = false, toolTip = "Opens the nametags settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => rightHanded = true, disableMethod =() => rightHanded = false, toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => disableNotifications = false, disableMethod =() => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => fpsCounter = true, disableMethod =() => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => disconnectButton = true, disableMethod =() => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod."},
                new ButtonInfo { buttonText = "Change Speedboost Speed", overlapText = "Change Speedboost Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeSpeedboostSpeed(), isTogglable = false, toolTip = "Changes the speed of the speedboost mod."},
                new ButtonInfo { buttonText = "Change WASD Fly Speed", overlapText = "Change WASD Fly Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeWASDSpeed(), isTogglable = false, toolTip = "Changes the speed of the WASD fly mod."},
                new ButtonInfo { buttonText = "Change Car Monke Speed", overlapText = "Change Car Monke Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeCarMonkeSpeed(), isTogglable = false, toolTip = "Changes the speed of the car monke mod."},
                new ButtonInfo { buttonText = "Change Pull Speed", overlapText = "Change Pull Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangePullSpeed(), isTogglable = false, toolTip = "Changes the speed of the pull mod."},
            },

            new ButtonInfo[] { // Nametags Settings [4]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Name Nametags Size", overlapText = "Change Name Nametags Size <color=gray>[</color><color=green>Medium</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the size of the name nametags mod."},            },

            new ButtonInfo[] { // Room Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Disconnect", method =() => Room.Disconnect(), isTogglable = false, toolTip = "Disconnects you from the room."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine(), isTogglable = false, toolTip = "Connects you to the room UKRAINE."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE1 </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine1(), isTogglable = false, toolTip = "Connects you to the room UKRAINE1."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE2 </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine2(), isTogglable = false, toolTip = "Connects you to the room UKRAINE2."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE3 </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine3(), isTogglable = false, toolTip = "Connects you to the room UKRAINE3."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE4 </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine4(), isTogglable = false, toolTip = "Connects you to the room UKRAINE4."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> UKRAINE5 </color><color=gray>]</color>", method =() => Room.JoinRoomUkraine5(), isTogglable = false, toolTip = "Connects you to the room UKRAINE5."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> VANVANI41 </color><color=gray>]</color>", method =() => Room.JoinRoomVanvani41(), isTogglable = false, toolTip = "Connects you to the room VANVANI41."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> V41FAN </color><color=gray>]</color>", method =() => Room.JoinRoomV41Fan(), isTogglable = false, toolTip = "Connects you to the room V41FAN."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> PBBV </color><color=gray>]</color>", method =() => Room.JoinRoomPBBV(), isTogglable = false, toolTip = "Connects you to the room PBBV."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> DAISY09 </color><color=gray>]</color>", method =() => Room.JoinRoomDAISY09(), isTogglable = false, toolTip = "Connects you to the DAISY09."},
                new ButtonInfo { buttonText = "Connect to Room <color=gray>[</color><color=green> ECHO </color><color=gray>]</color>", method =() => Room.JoinRoomECHO(), isTogglable = false, toolTip = "Connects you to the room ECHO."},
            },

            new ButtonInfo[] { // Movement Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Platforms <color=gray>[</color><color=green> G </color><color=gray>]</color>", method =() => Movement.GripPlatforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Platforms <color=gray>[</color><color=green> T </color><color=gray>]</color>", method =() => Movement.TriggerPlatforms(), toolTip = "Spawns platforms on your hands when pressing trigger."},
                new ButtonInfo { buttonText = "Sticky Platforms <color=gray>[</color><color=green> G </color><color=gray>]</color>", method =() => Movement.GripStickyPlatforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Sticky Platforms <color=gray>[</color><color=green> T </color><color=gray>]</color>", method =() => Movement.TriggerStickyPlatforms(), toolTip = "Spawns platforms on your hands when pressing trigger."},
                new ButtonInfo { buttonText = "Fly <color=gray>[</color><color=green> A </color><color=gray>]</color>", method =() => Movement.Fly(), toolTip = "Sends you forward when holding A."},
                new ButtonInfo { buttonText = "Noclip Fly <color=gray>[</color><color=green> A </color><color=gray>]</color>", method =() => Movement.Fly(), toolTip = "Sends you forward when holding A with Noclip."},
                new ButtonInfo { buttonText = "WASD Fly <color=gray>[</color><color=green> WASD </color><color=gray>]</color>", method =() => Movement.WASDFly(), toolTip = "Fly on WASD!!"},
                new ButtonInfo { buttonText = "Noclip <color=gray>[</color><color=green> RT </color><color=gray>]</color>", method =() => Movement.NoclipRT(), toolTip = "Noclips you when holding right trigger."},
                new ButtonInfo { buttonText = "Noclip <color=gray>[</color><color=green> LT </color><color=gray>]</color>", method =() => Movement.NoclipLT(), toolTip = "Noclips you when holding right trigger."},
                new ButtonInfo { buttonText = "Speedboost", method =() => Movement.Speedboost(), toolTip = "Makes you faster."},
                new ButtonInfo { buttonText = "Teleport Gun <color=gray>[</color><color=green> G </color><color=gray>]</color>", method =() => Movement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger."},
                new ButtonInfo { buttonText = "Car Monke <color=gray>[</color><color=green> G </color><color=gray>]</color>", method =() => Movement.CarMonkeG(), toolTip = "Ride forward when holding right grip and back when holding left grip."},
                new ButtonInfo { buttonText = "Car Monke <color=gray>[</color><color=green> G </color><color=gray>]</color>", method =() => Movement.CarMonkeT(), toolTip = "Ride forward when holding right trigger and back when holding left trigger."},
                new ButtonInfo { buttonText = "Ghost Monke <color=gray>[</color><color=green> XH </color><color=gray>]</color>", method =() => Movement.GhostMonkeH(), toolTip = "Freezes you when holding X."},
                new ButtonInfo { buttonText = "Ghost Monke <color=gray>[</color><color=green> XT </color><color=gray>]</color>", method =() => Movement.GhostMonkeT(), toolTip = "Freezes you when pressing X."},
                new ButtonInfo { buttonText = "Invis Monke <color=gray>[</color><color=green> AH </color><color=gray>]</color>", method =() => Movement.InvisMonkeH(), toolTip = "Making you invisible when holding A."},
                new ButtonInfo { buttonText = "Invis Monke <color=gray>[</color><color=green> AT </color><color=gray>]</color>", method =() => Movement.InvisMonkeT(), toolTip = "Making you invisible when pressing A."},
                new ButtonInfo { buttonText = "Spider Monke <color=gray>[</color><color=green> LWLT </color><color=gray>]</color>", method =() => Movement.SpiderMonkeLWLT(), toolTip = "Making you like a spider on left wall when holding left trigger."},
                new ButtonInfo { buttonText = "Spider Monke <color=gray>[</color><color=green> LWLG </color><color=gray>]</color>", method =() => Movement.SpiderMonkeLWLG(), toolTip = "Making you like a spider on left wall when holding left grip."},
                new ButtonInfo { buttonText = "Pull Mod <color=gray>[</color><color=green> RG </color><color=gray>]</color>", method =() => Movement.PullModLG(), toolTip = "Pulls you when holding right grip."},
                new ButtonInfo { buttonText = "Pull Mod <color=gray>[</color><color=green> LG </color><color=gray>]</color>", method =() => Movement.PullModRG(), toolTip = "Pulls you when holding left grip."},
                new ButtonInfo { buttonText = "Pull Mod <color=gray>[</color><color=green> RT </color><color=gray>]</color>", method =() => Movement.PullModLT(), toolTip = "Pulls you when holding right trigger."},
                new ButtonInfo { buttonText = "Pull Mod <color=gray>[</color><color=green> LT </color><color=gray>]</color>", method =() => Movement.PullModRT(), toolTip = "Pulls you when holding left trigger."},
            },

            new ButtonInfo[] { // Safety Mods [7]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=green> Disconnect </color><color=gray>]</color>", method =() => Safety.AntiReportDisconnect(), toolTip = "Disconnects you when someone tries to report you."},
                new ButtonInfo { buttonText = "No Finger Touch", method =() => Safety.NoFingerTouch(), toolTip = "Disables finger touches."},
                new ButtonInfo { buttonText = "Close Gorilla Tag", method =() => Safety.CloseGorillaTag(), isTogglable = false},
                new ButtonInfo { buttonText = "Restart Gorilla Tag", method =() => Safety.RestartGorillaTag(), isTogglable = false},
            },

            new ButtonInfo[] { // Fun/Challenge Mods [8]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=orange> Close Gorilla Tag </color><color=gray>]</color>", method =() => FunChallenge.AntiReportCloseGorillaTag(), toolTip = "Closes Gorilla Tag when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=orange> Restart Gorilla Tag </color><color=gray>]</color>", method =() => FunChallenge.AntiReportRestartGorillaTag(), toolTip = "Restarts Gorilla Tag when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=red> SHUTDOWN PC </color><color=gray>]</color>", method =() => FunChallenge.AntiReportSHUTDOWNPC(), toolTip = "Shutdowns PC when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=red> RESTART PC </color><color=gray>]</color>", method =() => FunChallenge.AntiReportRESTARTPC(), toolTip = "Restarts PC when someone tries to report you."},
                new ButtonInfo { buttonText = "<color=red>SHUTDOWN PC</color>", method =() => FunChallenge.SHUTDOWNPC(), isTogglable = false},
                new ButtonInfo { buttonText = "<color=red>RESTART PC</color>", method =() => FunChallenge.RESTARTPC(), isTogglable = false},
            },

            new ButtonInfo[] { // Nametags Mods [9]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Name Nametags", method =() => Nametags.nameTags = !Nametags.nameTags, toolTip = "Turns on Name Nametag."},
            },
        };
    }
}