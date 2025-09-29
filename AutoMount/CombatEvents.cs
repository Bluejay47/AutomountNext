using Kingmaker.PubSubSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker;
using static AutoMountNext.Utils;
using AutoMountNext.Features;
using System.Collections.Generic;
using UnityEngine;

namespace AutoMountNext
{
    public class CombatEventHandler : IUnitCombatHandler, IGlobalSubscriber, ISubscriber
    {
        private static readonly Dictionary<UnitEntityData, float> pendingCombatMounts = new Dictionary<UnitEntityData, float>();
        private static readonly Dictionary<UnitEntityData, float> pendingCombatDismounts = new Dictionary<UnitEntityData, float>();

        public void HandleUnitJoinCombat(UnitEntityData unit)
        {
            try
            {
                LogDebug($"CombatEventHandler.HandleUnitJoinCombat: {unit.CharacterName} joined combat");

                // Check if this is a player party member
                if (!Game.Instance.Player.Party.Contains(unit))
                    return;

                // Schedule mount/dismount for next frame to avoid event system conflicts
                if (HasAutoMountWhenInCombatBuff(unit))
                {
                    LogDebug($"CombatEventHandler.HandleUnitJoinCombat: {unit.CharacterName} has auto mount when in combat enabled, scheduling mount");
                    pendingCombatMounts[unit] = Time.time + 0.1f; // Small delay
                    pendingCombatDismounts.Remove(unit);
                }
                else
                {
                    LogDebug($"CombatEventHandler.HandleUnitJoinCombat: {unit.CharacterName} does not have auto mount when in combat enabled, scheduling dismount");
                    pendingCombatDismounts[unit] = Time.time + 0.1f; // Small delay
                    pendingCombatMounts.Remove(unit);
                }
            }
            catch (System.Exception ex)
            {
                LogDebug($"CombatEventHandler.HandleUnitJoinCombat: Error handling {unit?.CharacterName}: {ex.Message}");
            }
        }

        public void HandleUnitLeaveCombat(UnitEntityData unit)
        {
            try
            {
                LogDebug($"CombatEventHandler.HandleUnitLeaveCombat: {unit.CharacterName} left combat");

                // Check if this is a player party member
                if (!Game.Instance.Player.Party.Contains(unit))
                    return;

                // Schedule mount/dismount for next frame to avoid event system conflicts
                if (HasAutoMountWhenNotInCombatBuff(unit))
                {
                    LogDebug($"CombatEventHandler.HandleUnitLeaveCombat: {unit.CharacterName} has auto mount when not in combat enabled, scheduling mount");
                    pendingCombatMounts[unit] = Time.time + 0.1f; // Small delay
                    pendingCombatDismounts.Remove(unit);
                }
                else
                {
                    LogDebug($"CombatEventHandler.HandleUnitLeaveCombat: {unit.CharacterName} does not have auto mount when not in combat enabled, scheduling dismount");
                    pendingCombatDismounts[unit] = Time.time + 0.1f; // Small delay
                    pendingCombatMounts.Remove(unit);
                }
            }
            catch (System.Exception ex)
            {
                LogDebug($"CombatEventHandler.HandleUnitLeaveCombat: Error handling {unit?.CharacterName}: {ex.Message}");
            }
        }

        // Static method to process pending operations - called from Main.OnUpdate
        public static void ProcessPendingOperations()
        {
            var currentTime = Time.time;
            var toMount = new List<UnitEntityData>();
            var toDismount = new List<UnitEntityData>();

            // Collect units ready for mounting
            foreach (var kvp in pendingCombatMounts)
            {
                if (currentTime >= kvp.Value)
                {
                    toMount.Add(kvp.Key);
                }
            }

            // Collect units ready for dismounting
            foreach (var kvp in pendingCombatDismounts)
            {
                if (currentTime >= kvp.Value)
                {
                    toDismount.Add(kvp.Key);
                }
            }

            // Execute mounting operations
            foreach (var unit in toMount)
            {
                try
                {
                    TryMountUnit(unit);
                    pendingCombatMounts.Remove(unit);
                }
                catch (System.Exception ex)
                {
                    LogDebug($"ProcessPendingOperations: Error mounting {unit?.CharacterName}: {ex.Message}");
                    pendingCombatMounts.Remove(unit);
                }
            }

            // Execute dismounting operations
            foreach (var unit in toDismount)
            {
                try
                {
                    TryDismountUnit(unit);
                    pendingCombatDismounts.Remove(unit);
                }
                catch (System.Exception ex)
                {
                    LogDebug($"ProcessPendingOperations: Error dismounting {unit?.CharacterName}: {ex.Message}");
                    pendingCombatDismounts.Remove(unit);
                }
            }
        }

        private static void TryMountUnit(UnitEntityData unit)
        {
            var pet = GetRidersPet(unit, true);
            if (pet != null && CheckCanMount(unit, pet, true))
            {
                var mountGuid = new System.Guid("d340d820867cf9741903c9be9aed1ccc");
                var mountAbility = unit.ActivatableAbilities.Enumerable.Find(a => a.Blueprint.AssetGuid.CompareTo(mountGuid) == 0);

                if (mountAbility != null && !mountAbility.IsOn)
                {
                    unit.Ensure<Kingmaker.UnitLogic.Parts.UnitPartRider>().Mount(pet);

                    if (Settings.IsCombatLoggingEnabled())
                    {
                        ConsoleLog($"AutoMount Combat: {unit.CharacterName} mounted {pet.CharacterName}.", "", new UnityEngine.Color(0f, 0.39f, 0f), false);
                    }
                }
            }
        }

        private static void TryDismountUnit(UnitEntityData unit)
        {
            var pet = GetRidersPet(unit, false);
            if (pet != null && unit.RiderPart != null)
            {
                unit.RiderPart.Dismount();

                if (Settings.IsCombatLoggingEnabled())
                {
                    ConsoleLog($"AutoMount Combat: {unit.CharacterName} dismounted {pet.CharacterName}.", "", new UnityEngine.Color(0f, 0.27f, 0.54f), false);
                }
            }
        }

        private static bool HasAutoMountWhenInCombatBuff(UnitEntityData unit)
        {
            if (unit?.Buffs == null) return false;
            var buff = BlueprintCore.Utils.BlueprintTool.Get<Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff>(AutoMountWhenInCombat.buffGuid);
            return unit.Buffs.HasFact(buff);
        }

        private static bool HasAutoMountWhenNotInCombatBuff(UnitEntityData unit)
        {
            if (unit?.Buffs == null) return false;
            var buff = BlueprintCore.Utils.BlueprintTool.Get<Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff>(AutoMountWhenNotInCombat.buffGuid);
            return unit.Buffs.HasFact(buff);
        }
    }
}