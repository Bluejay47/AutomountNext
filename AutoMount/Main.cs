using AutoMountNext.Events;
using Kingmaker;
using Kingmaker.Blueprints.Area;
using Kingmaker.Blueprints;
using Kingmaker.Enums;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Parts;
using UnityEngine;
using static AutoMountNext.Settings;
using static AutoMountNext.Utils;
using static UnityModManagerNet.UnityModManager;
using UnityModManagerNet;
using AutoMountNext.Features;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Entities;

namespace AutoMountNext
{
	public static class Main
	{

		public static UnityModManager.ModEntry ModEntry;

		public static bool Enabled;
		public static ModEntry.ModLogger Logger;
		private static Harmony m_harmony;
		internal static ModEntry modEntry;
		private static OnAreaLoad m_area_load_handler;
		private static CombatEventHandler m_combat_event_handler;
		private static Guid m_mount_ability_guid = new("d340d820867cf9741903c9be9aed1ccc");
		private static bool m_force_mount = false;

		public static bool Load(ModEntry modEntry)
		{
			Main.modEntry = modEntry;
			Logger = modEntry.Logger;

			Logger.Log("Loading");

			modEntry.OnToggle = OnToggle;
			modEntry.OnUpdate = OnUpdate;

			m_harmony = new Harmony(modEntry.Info.Id);
			m_harmony.PatchAll(Assembly.GetExecutingAssembly());

			m_area_load_handler = new OnAreaLoad();
			EventBus.Subscribe(m_area_load_handler);

			m_combat_event_handler = new CombatEventHandler();
			EventBus.Subscribe(m_combat_event_handler);


			return true;
		}

		static bool OnToggle(ModEntry modEntry, bool value)
		{
			Enabled = value;
			return true;
		}

		static void OnUpdate(ModEntry modEntry, float delta)
		{
			if (m_force_mount)
			{
				Mount(true);
				m_force_mount = false;
			}

			// Process pending combat mount/dismount operations
			CombatEventHandler.ProcessPendingOperations();
		}

		public static void ForceMount()
		{
			m_force_mount = true;
		}

		public static void GrantAutoMountAbilities()
		{
			LogDebug("Main.GrantAutoMountAbilities: Granting automount abilities to party members");

			if (Game.Instance?.Player?.Party == null)
			{
				LogDebug("Main.GrantAutoMountAbilities: Party is not available");
				return;
			}

			var combatStartFeature = BlueprintTool.Get<BlueprintFeature>(AutoMountWhenInCombat.featGuid);
			var combatEndFeature = BlueprintTool.Get<BlueprintFeature>(AutoMountWhenNotInCombat.featGuid);

			if (combatStartFeature == null)
			{
				LogDebug("Main.GrantAutoMountAbilities: AutoMountWhenInCombat feature not found");
				return;
			}

			if (combatEndFeature == null)
			{
				LogDebug("Main.GrantAutoMountAbilities: AutoMountWhenNotInCombat feature not found");
				return;
			}

			LogDebug($"Main.GrantAutoMountAbilities: Found features - WhenInCombat: {combatStartFeature.name}, WhenNotInCombat: {combatEndFeature.name}");

			foreach (var unit in Game.Instance.Player.Party)
			{
				if (unit?.Progression == null) continue;

				// Grant Auto Mount When In Combat feature if not already present
				if (!unit.Progression.Features.HasFact(combatStartFeature))
				{
					unit.Progression.Features.AddFeature(combatStartFeature);
					LogDebug($"Main.GrantAutoMountAbilities: Granted AutoMountWhenInCombat to {unit.CharacterName}");
				}

				// Grant Auto Mount When Not In Combat feature if not already present
				if (!unit.Progression.Features.HasFact(combatEndFeature))
				{
					unit.Progression.Features.AddFeature(combatEndFeature);
					LogDebug($"Main.GrantAutoMountAbilities: Granted AutoMountWhenNotInCombat to {unit.CharacterName}");
				}
			}
		}

		public static void Mount(bool on)
		{
            foreach (var rider in Game.Instance.Player.Party)
            {

				var pet = GetRidersPet(rider, on);

				if (pet != null)
				{
					if (rider.State.HasCondition(UnitCondition.DisableMountRiding))
					{
						if (IsOnAreaMountEnabled())
						{
							ConsoleLog("AutoMount: Mounting is currently disabled for this area.", "", new Color(0.5f, 0f, 0f), false);
						}
						break;
					}
					else
					{
						if (CheckCanMount(rider, pet, on))
						{
							var mount = rider.ActivatableAbilities.Enumerable.Find(a => a.Blueprint.AssetGuid.CompareTo(m_mount_ability_guid) == 0);

							if (mount != null)
							{
								if (mount.IsOn && !on)
								{
									rider.RiderPart?.Dismount();

									if (IsCombatLoggingEnabled())
									{
										ConsoleLog($"AutoMount: {rider.CharacterName} dismounted {pet.CharacterName}.", "", new Color(0f, 0.27f, 0.54f), false);
									}
								}
								else if (!mount.IsOn && on)
								{
									// If the pet is Aivu and the area is the Drezen basement showdown with Camellia, needs a specific exclusion.
									if (pet == rider.GetPet(PetType.AzataHavocDragon))
									{
										BlueprintArea currentArea = Game.Instance.CurrentlyLoadedArea;
										BlueprintAreaPart currentAreaPart = Game.Instance.CurrentlyLoadedAreaPart.Or<BlueprintAreaPart>((BlueprintAreaPart)currentArea);
										string AreaCamBase = "0670085bf3fe4694d91e2ea159dee079"; // \World\Areas\Act_3_DemonsHerecy\DrezenCapital\DrezenCapital_AbandonedBuildingBasement.jbp

										if (currentAreaPart.AssetGuid.ToString() == AreaCamBase)
										{
											// Aivu has an added flag that allows her to be excepted from the HideAllPets function, so that needs to be accounted for in those
											// areas that don't also have the DisableMountRiding flag. Seems like the only instance is the basement confrontation in Drezen.
											LogDebug($"Main.Mount: Area is Drezen basement confrontation with Camellia and Aivu is present, bypassing area check.");

											goto AivuJump;
										}
									}

									// Prevent manual mounting in problem areas
									if (CheckEtudesForPetBlockers())
									{
										LogDebug("Main.Mount: Blocked hotkey mount attempt in problem area.");
										
										if (IsCombatLoggingEnabled())
										{
											ConsoleLog($"AutoMount: Pets are unavailable in this area, skipping {rider.CharacterName}'s mount attempt.", "", new Color(0.5f, 0f, 0f), false);
										}
										
										break;
									}

								AivuJump:

									rider.Ensure<UnitPartRider>().Mount(pet);

									if (IsCombatLoggingEnabled())
									{
										ConsoleLog($"AutoMount: {rider.CharacterName} mounted {pet.CharacterName}.", "", new Color(0f, 0.39f, 0f), false);
									}
								}
							}
						}
					}
				}
            }
        }
    }
}
