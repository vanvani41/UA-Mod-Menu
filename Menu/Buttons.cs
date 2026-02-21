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

                new ButtonInfo { buttonText = "Room Mods", method =() => currentCategory = 4, isTogglable = false, toolTip = "Opens the room mods tab."},
                new ButtonInfo { buttonText = "Movement Mods", method =() => currentCategory = 5, isTogglable = false, toolTip = "Opens the movement mods tab."},
                new ButtonInfo { buttonText = "Safety Mods", method =() => currentCategory = 6, isTogglable = false, toolTip = "Opens the safety mods tab."},
                new ButtonInfo { buttonText = "Fun/Challenge Mods", method =() => currentCategory = 7, isTogglable = false, toolTip = "Opens the Fun/Challenge mods tab."},
                new ButtonInfo { buttonText = "Nametags Mods", method =() => currentCategory = 8, isTogglable = false, toolTip = "Opens the Nametags mods tab."},
            },

            new ButtonInfo[] { // Settings [1]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                new ButtonInfo { buttonText = "Menu", method =() => currentCategory = 2, isTogglable = false, toolTip = "Opens the settings for the menu."},
                new ButtonInfo { buttonText = "Movement", method =() => currentCategory = 3, isTogglable = false, toolTip = "Opens the movement settings for the menu."},
            },

            new ButtonInfo[] { // Menu Settings [2]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},
                new ButtonInfo { buttonText = "Right Hand", enableMethod =() => rightHanded = true, disableMethod =() => rightHanded = false, toolTip = "Puts the menu on your right hand."},
                new ButtonInfo { buttonText = "Notifications", enableMethod =() => disableNotifications = false, disableMethod =() => disableNotifications = true, enabled = !disableNotifications, toolTip = "Toggles the notifications."},
                new ButtonInfo { buttonText = "FPS Counter", enableMethod =() => fpsCounter = true, disableMethod =() => fpsCounter = false, enabled = fpsCounter, toolTip = "Toggles the FPS counter."},
                new ButtonInfo { buttonText = "Disconnect Button", enableMethod =() => disconnectButton = true, disableMethod =() => disconnectButton = false, enabled = disconnectButton, toolTip = "Toggles the disconnect button."},
                new ButtonInfo { buttonText = "Discord Rich Presence", enableMethod =() => rpc = true, disableMethod =() => rpc = false, enabled = rpc, toolTip = "Toggles the Discord Rich Presence."},
            },

            new ButtonInfo[] { // Movement Settings [3]
                new ButtonInfo { buttonText = "Return to Settings", method =() => currentCategory = 1, isTogglable = false, toolTip = "Returns to the main settings page for the menu."},

                new ButtonInfo { buttonText = "Change Fly Speed", overlapText = "Change Fly Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeFlySpeed(), isTogglable = false, toolTip = "Changes the speed of the fly mod."},
                new ButtonInfo { buttonText = "Change Speedboost Speed", overlapText = "Change Speedboost Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeSpeedboostSpeed(), isTogglable = false, toolTip = "Changes the speed of the speedboost mod."},
                new ButtonInfo { buttonText = "Change WASD Fly Speed", overlapText = "Change WASD Fly Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeWASDSpeed(), isTogglable = false, toolTip = "Changes the speed of the WASD fly mod."},
                new ButtonInfo { buttonText = "Change Car Monke Speed", overlapText = "Change Car Monke Speed <color=gray>[</color><color=green>Normal</color><color=gray>]</color>", method =() => Mods.Settings.Movement.ChangeCarMonkeSpeed(), isTogglable = false, toolTip = "Changes the speed of the car monke mod."},
            },

            new ButtonInfo[] { // Room Mods [4]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Disconnect", method =() => NetworkSystem.Instance.ReturnToSinglePlayer(), isTogglable = false, toolTip = "Disconnects you from the room."},
            },

            new ButtonInfo[] { // Movement Mods [5]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Platforms <color=gray>[</color><color=green>G</color><color=gray>]</color>", method =() => Movement.GripPlatforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Platforms <color=gray>[</color><color=green>T</color><color=gray>]</color>", method =() => Movement.TriggerPlatforms(), toolTip = "Spawns platforms on your hands when pressing trigger."},
                new ButtonInfo { buttonText = "Sticky Platforms <color=gray>[</color><color=green>G</color><color=gray>]</color>", method =() => Movement.GripStickyPlatforms(), toolTip = "Spawns platforms on your hands when pressing grip."},
                new ButtonInfo { buttonText = "Sticky Platforms <color=gray>[</color><color=green>T</color><color=gray>]</color>", method =() => Movement.TriggerStickyPlatforms(), toolTip = "Spawns platforms on your hands when pressing trigger."},
                new ButtonInfo { buttonText = "Fly <color=gray>[</color><color=green>A</color><color=gray>]</color>", method =() => Movement.Fly(), toolTip = "Sends you forward when holding A."},
                new ButtonInfo { buttonText = "WASD Fly <color=gray>[</color><color=green>WASD</color><color=gray>]</color>", method =() => Movement.WASDFly(), toolTip = "Fly on WASD!!"},
                new ButtonInfo { buttonText = "Noclip <color=gray>[</color><color=green>RT</color><color=gray>]</color>", method =() => Movement.Noclip(), toolTip = "Noclips you when holding right trigger."},
                new ButtonInfo { buttonText = "Speedboost", method =() => Movement.Speedboost(), toolTip = "Makes you faster."},
                new ButtonInfo { buttonText = "Teleport Gun <color=gray>[</color><color=green>G</color><color=gray>]</color>", method =() => Movement.TeleportGun(), toolTip = "Teleports you to wherever your pointer is when pressing trigger."},
                new ButtonInfo { buttonText = "Car Monke <color=gray>[</color><color=green>G</color><color=gray>]</color>", method =() => Movement.CarMonke(), toolTip = "Ride forward when holding right grip and back when holding left grip."},
                new ButtonInfo { buttonText = "Ghost Monke <color=gray>[</color><color=green>X</color><color=gray>]</color>", method =() => Movement.GhostMonke(), toolTip = "Freezes you when holding X."},
                new ButtonInfo { buttonText = "Invis Monke <color=gray>[</color><color=green>A</color><color=gray>]</color>", method =() => Movement.InvisMonke(), toolTip = "Making you invisible when holding A."},
            },

            new ButtonInfo[] { // Safety Mods [6]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=green>Disconnect</color><color=gray>]</color>", method =() => Safety.AntiReportDisconnect(), toolTip = "Disconnects you when someone tries to report you."},
                new ButtonInfo { buttonText = "No Finger Touch", method =() => Safety.NoFingerTouch(), toolTip = "Disables finger touches."},
                new ButtonInfo { buttonText = "Close Gorilla Tag", method =() => Safety.CloseGorillaTag(), isTogglable = false},
                new ButtonInfo { buttonText = "Restart Gorilla Tag", method =() => Safety.RestartGorillaTag(), isTogglable = false},
            },

            new ButtonInfo[] { // Fun/Challenge Mods [7]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},
                
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=orange>Close Gorilla Tag</color><color=gray>]</color>", method =() => FunChallenge.AntiReportCloseGorillaTag(), toolTip = "Closes Gorilla Tag when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=gold>Restart Gorilla Tag</color><color=gray>]</color>", method =() => FunChallenge.AntiReportRestartGorillaTag(), toolTip = "Restarts Gorilla Tag when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=red>SHUTDOWN PC</color><color=gray>]</color>", method =() => FunChallenge.AntiReportSHUTDOWNPC(), toolTip = "Shutdowns PC when someone tries to report you."},
                new ButtonInfo { buttonText = "Anti Report <color=gray>[</color><color=red>RESTART PC</color><color=gray>]</color>", method =() => FunChallenge.AntiReportRESTARTPC(), toolTip = "Restarts PC when someone tries to report you."},
                new ButtonInfo { buttonText = "<color=red>SHUTDOWN PC</color>", method =() => FunChallenge.SHUTDOWNPC(), isTogglable = false},
                new ButtonInfo { buttonText = "<color=red>RESTART PC</color>", method =() => FunChallenge.RESTARTPC(), isTogglable = false},
            },

            new ButtonInfo[] { // Nametags Mods [8]
                new ButtonInfo { buttonText = "Return to Main", method =() => currentCategory = 0, isTogglable = false, toolTip = "Returns to the main page of the menu."},

                new ButtonInfo { buttonText = "Name Nametags", method =() => Nametags.nameTags = !Nametags.nameTags, toolTip = "Turns on Name Nametag."},
                new ButtonInfo { buttonText = "ID Nametags", method =() => Nametags.idTags = !Nametags.idTags, toolTip = "Turns on ID Nametag."},
                new ButtonInfo { buttonText = "Color Nametags", method =() => Nametags.colorTags = !Nametags.colorTags, toolTip = "Turns on Color Nametag."},
                new ButtonInfo { buttonText = "Platform Nametags", method =() => Nametags.platformTags = !Nametags.platformTags, toolTip = "Turns on Platform Nametag."},
                new ButtonInfo { buttonText = "Mods Nametags", method =() => Nametags.modsTags = !Nametags.modsTags, toolTip = "Turns on Mods Nametag."},
                new ButtonInfo { buttonText = "FPS Nametags", method =() => Nametags.fpsTags = !Nametags.fpsTags, toolTip = "Turns on FPS Nametag."},
                new ButtonInfo { buttonText = "HZ Nametags", method =() => Nametags.hzTags = !Nametags.hzTags, toolTip = "Turns on HZ Nametag."},
                new ButtonInfo { buttonText = "Lag Nametags", method =() => Nametags.lagTags = !Nametags.lagTags, toolTip = "Turns on Lag Nametag."},
            },
        };
    }
}