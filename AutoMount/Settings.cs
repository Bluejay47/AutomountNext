using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Localization;
using Kingmaker.UI;
using ModMenu.Settings;
using KeyBinding = ModMenu.Settings.KeyBinding;
using UnityEngine;
using UnityModManagerNet;
using static AutoMountNext.Strings.ModStrings;
using static AutoMountNext.Utils;
using AutoMountNext.Features;
using HarmonyLib;
using Kingmaker;

namespace AutoMountNext
{
	public static class Settings
	{
		private static bool Initialized = false;
		
		private static readonly string RootKey = "automountnext";
		public static readonly string MountOnAreaEnter = "areaentermount";
		public static readonly string RideAivu = "rideaivu";
		public static readonly string ConsoleOutput = "consoleoutput";
		public static readonly string ConsoleDebug = "consoledebug";
		public static readonly string MountHotKey = "hotkeys.mounthotkey";
		public static readonly string DismountHotKey = "hotkeys.dismounthotkey";
		public static readonly string ToggleAutoMountInCombatHotKey = "hotkeys.toggleautomountincombat";
		public static readonly string ToggleAutoMountOutCombatHotKey = "hotkeys.toggleautomountoutcombat";

		private static SettingsBuilder MMSettings = SettingsBuilder.New(RootKey, GetString(GetKey("automount-title"), "AutoMountNext"));
		
		public static void Init()
		{
			if (Initialized)
			{
				LogDebug("ModMenu settings already initialised");
				return;
			}

			Main.Logger.Log("Initialising ModMenu settings");

			MMSettings.SetMod(Main.modEntry);
			MMSettings.SetModDescription(ModDesc);

			var illustration = Utilities.CreateSprite("AutomountNext.Img.mountpeace.png");
			if (illustration != null)
			{
				MMSettings.SetModIllustration(illustration);
			}

			MMSettings.AddToggle(
				Toggle.New(
					GetKey(MountOnAreaEnter),
					true,
					ToggleMountOnEnterDesc)
				.WithLongDescription(ToggleMountOnEnterDescLong)
			);

			MMSettings.AddToggle(
				Toggle.New(
					GetKey(RideAivu),
					true,
					ToggleRideAivuDesc)
				.WithLongDescription(ToggleRideAivuDescLong)
			);

			MMSettings.AddToggle(
				Toggle.New(
					GetKey(ConsoleOutput),
					false,
					ToggleConsoleOutputDesc)
				.WithLongDescription(ToggleConsoleOutputDescLong)
			);

			MMSettings.AddToggle(
				Toggle.New(
					GetKey(ConsoleDebug),
					false,
					ToggleConsoleDebugDesc)
				.WithLongDescription(ToggleConsoleDebugDescLong)
			);

			var Hotkeys = MMSettings.AddSubHeader(HeaderHotkeysDesc, true);

			Hotkeys.AddKeyBinding(
				KeyBinding.New(
					GetKey(MountHotKey),
					KeyboardAccess.GameModesGroup.All,
					ToggleMountHotKeyDesc)
				.SetPrimaryBinding(KeyCode.A, withCtrl: true, withShift: true)
				.WithLongDescription(ToggleMountHotKeyDescLong),
				() => Main.Mount(true)
			);

			Hotkeys.AddKeyBinding(
				KeyBinding.New(
					GetKey(DismountHotKey),
					KeyboardAccess.GameModesGroup.All,
					ToggleDismountHotKeyDesc)
				.SetPrimaryBinding(KeyCode.D, withCtrl: true, withShift: true)
				.WithLongDescription(ToggleDismountHotKeyDescLong),
				() => Main.Mount(false)
			);

			ModMenu.ModMenu.AddSettings(MMSettings);
			Initialized = true;
			Main.Logger.Log("ModMenu settings initialisation complete");
		}

		internal static bool IsEnabled(string key)
		{
			return ModMenu.ModMenu.GetSettingValue<bool>(GetKey(key));
		}

		internal static bool IsOnAreaMountEnabled()
		{
			return ModMenu.ModMenu.GetSettingValue<bool>(GetKey("areaentermount"));
		}

		internal static bool IsCombatLoggingEnabled()
		{
			return ModMenu.ModMenu.GetSettingValue<bool>(GetKey("consoleoutput"));
		}

		internal static bool IsCombatLogDebugEnabled()
		{
			return ModMenu.ModMenu.GetSettingValue<bool>(GetKey("consoledebug"));
		}

		private static string GetKey(string partialKey)
		{
			return $"{RootKey}.{partialKey}";
		}

		private static LocalizedString GetString(string partialKey, string text)
		{
			return Utilities.CreateString(GetKey(partialKey), text);
		}

	}

	[HarmonyPatch(typeof(BlueprintsCache))]
	static class BlueprintsCache_Postfix
	{
		[HarmonyPatch(nameof(BlueprintsCache.Init)), HarmonyPostfix]
		static void Postfix()
		{
			Settings.Init();
			AutoMountWhenInCombat.Configure();
			AutoMountWhenNotInCombat.Configure();
		}
	}


	[HarmonyPatch(typeof(Kingmaker.Player), nameof(Kingmaker.Player.AddCompanion))]
	static class Player_AddCompanion_Postfix
	{
		static void Postfix(Kingmaker.EntitySystem.Entities.UnitEntityData value)
		{
			// Grant abilities to new party member
			LogDebug($"Player_AddCompanion_Postfix: New companion {value?.CharacterName} added to party");
			Main.GrantAutoMountAbilities();
		}
	}
}
