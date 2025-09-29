using Kingmaker.PubSubSystem;
using static AutoMountNext.Main;
using static AutoMountNext.Settings;
using static AutoMountNext.Utils;
using Kingmaker;
using AutoMountNext.Features;

namespace AutoMountNext.Events
{
    public class OnAreaLoad : IAreaHandler
    {
        public void OnAreaDidLoad()
        {
			// Grant abilities to party members when area loads
			GrantAutoMountAbilities();

			// Check for etude blockers first
			if (CheckEtudesForPetBlockers())
			{
				LogDebug("Events.OnAreaDidLoad: Skipping area mount due to etude check.");
				return;
			}

			// Mount characters who have the "auto mount when not in combat" preference enabled
			foreach (var unit in Game.Instance.Player.Party)
			{
				try
				{
					if (HasAutoMountWhenNotInCombatBuff(unit))
					{
						LogDebug($"Events.OnAreaDidLoad: {unit.CharacterName} has auto mount when not in combat enabled, attempting mount");
						var pet = GetRidersPet(unit, true);
						if (pet != null && CheckCanMount(unit, pet, true))
						{
							var mountGuid = new System.Guid("d340d820867cf9741903c9be9aed1ccc");
							var mountAbility = unit.ActivatableAbilities.Enumerable.Find(a => a.Blueprint.AssetGuid.CompareTo(mountGuid) == 0);

							if (mountAbility != null && !mountAbility.IsOn)
							{
								unit.Ensure<Kingmaker.UnitLogic.Parts.UnitPartRider>().Mount(pet);
								LogDebug($"Events.OnAreaDidLoad: {unit.CharacterName} mounted {pet.CharacterName}");
							}
						}
					}
					else
					{
						LogDebug($"Events.OnAreaDidLoad: {unit.CharacterName} does not have auto mount when not in combat enabled, skipping");
					}
				}
				catch (System.Exception ex)
				{
					LogDebug($"Events.OnAreaDidLoad: Error mounting {unit?.CharacterName}: {ex.Message}");
				}
			}
        }

        public void OnAreaBeginUnloading()
        { }

        private static bool HasAutoMountWhenNotInCombatBuff(Kingmaker.EntitySystem.Entities.UnitEntityData unit)
        {
            if (unit?.Buffs == null) return false;
            var buff = BlueprintCore.Utils.BlueprintTool.Get<Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff>(AutoMountWhenNotInCombat.buffGuid);
            return unit.Buffs.HasFact(buff);
        }
    }
}
