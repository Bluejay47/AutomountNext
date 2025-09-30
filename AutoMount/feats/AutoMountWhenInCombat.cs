using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using Kingmaker.Blueprints.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics;
using Kingmaker.UnitLogic.Abilities;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using System;
using System.Collections.Generic;
using Kingmaker.UnitLogic;
using static AutoMountNext.Utils;
using AutoMountNext.Strings;

namespace AutoMountNext.Features {
    public class AutoMountWhenInCombat {
        private static readonly LogWrapper Logger = LogWrapper.Get("AutoMountWhenInCombat");

        public static readonly string featName = "AutoMountWhenInCombat";
        public static readonly string featGuid = "542a7b3b-07c7-4ecd-a02d-b00865622d90";

        public static readonly string buffName = "AutoMountWhenInCombatBuff";
        public static readonly string buffGuid = "799edf2e-68f8-4c69-bcbd-2471d0cfdf5a";

        public static readonly string abilityName = "AutoMountWhenInCombatAbility";
        public static readonly string abilityGuid = "1d3433ca-31ed-4ee4-934a-3f1c93fa6789";

        public static void Configure() {
            try {
                BlueprintFeature baseAbility = BlueprintTool.Get<BlueprintFeature>(FeatureRefs.BolsteredSpellFeat.ToString());
                var customIcon = Utilities.CreateSprite("AutomountNext.Img.mountcombat.png");

                // Auto Mount When In Combat Toggle Buff
                BuffConfigurator.New(buffName, buffGuid)
                .SetDisplayName(ModStrings.AutoMountWhenInCombatBuffName)
                .SetDescription(ModStrings.AutoMountWhenInCombatBuffDescription)
                .SetIcon(customIcon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

                var toggle = ActivatableAbilityConfigurator.New(abilityName, abilityGuid)
                .SetDisplayName(ModStrings.AutoMountWhenInCombatAbilityName)
                .SetDescription(ModStrings.AutoMountWhenInCombatAbilityDescription)
                .SetBuff(buffGuid)
                .SetIcon(customIcon)
                .Configure();

                BlueprintFeature feature = FeatureConfigurator.New(featName, featGuid)
                .SetDescription(ModStrings.AutoMountWhenInCombatAbilityDescription)
                .SetDisplayName(ModStrings.AutoMountWhenInCombatAbilityName)
                .SetIsClassFeature(false)
                .SetHideInUI(false)
                .SetHideInCharacterSheetAndLevelUp(false)
                .AddFacts(new() { toggle })
                .SetIcon(customIcon)
                .Configure();

            } catch (Exception ex) {
                Logger.Error(ex.ToString());
            }
        }
    }
}
