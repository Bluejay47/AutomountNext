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
    public class AutoMountWhenNotInCombat {
        private static readonly LogWrapper Logger = LogWrapper.Get("AutoMountWhenNotInCombat");

        public static readonly string featName = "AutoMountWhenNotInCombat";
        public static readonly string featGuid = "a3c4d5e6-f789-0123-4567-89abcdef0123";

        public static readonly string buffName = "AutoMountWhenNotInCombatBuff";
        public static readonly string buffGuid = "b4d5e6f7-8901-2345-6789-0abcdef12345";

        public static readonly string abilityName = "AutoMountWhenNotInCombatAbility";
        public static readonly string abilityGuid = "c5e6f789-0123-4567-890a-bcdef1234567";

        public static void Configure() {
            try {
                BlueprintFeature baseAbility = BlueprintTool.Get<BlueprintFeature>(FeatureRefs.BolsteredSpellFeat.ToString());
                var customIcon = Utilities.CreateSprite("AutomountNext.Img.mountpeace.png");

                // Auto Mount When Not In Combat Toggle Buff
                BuffConfigurator.New(buffName, buffGuid)
                .SetDisplayName(ModStrings.AutoMountWhenNotInCombatBuffName)
                .SetDescription(ModStrings.AutoMountWhenNotInCombatBuffDescription)
                .SetIcon(customIcon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();

                var toggle = ActivatableAbilityConfigurator.New(abilityName, abilityGuid)
                .SetDisplayName(ModStrings.AutoMountWhenNotInCombatAbilityName)
                .SetDescription(ModStrings.AutoMountWhenNotInCombatAbilityDescription)
                .SetBuff(buffGuid)
                .SetIcon(customIcon)
                .Configure();

                BlueprintFeature feature = FeatureConfigurator.New(featName, featGuid)
                .SetDescription(ModStrings.AutoMountWhenNotInCombatAbilityDescription)
                .SetDisplayName(ModStrings.AutoMountWhenNotInCombatAbilityName)
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