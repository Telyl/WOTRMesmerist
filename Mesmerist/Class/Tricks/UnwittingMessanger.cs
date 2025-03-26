using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.StoryEx;
using BlueprintCore.Utils.Types;
using Kingmaker.Designers.Mechanics.Buffs;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff;

namespace Mesmerist.Class.Tricks
{
    internal class UnwittingMessanger
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("UnwittingMessanger",
                                          "UnwittingMessanger.Name",
                                          "UnwittingMessanger.Description",
                                          AbilityRefs.SignetOfHouseVespertilioAbilityAthletics.Reference.Get().Icon,
                                          Guids.UnwittingMessanger,
                                          Guids.UnwittingMessangerAbility,
                                          Guids.UnwittingMessangerBuff);

            BuffConfigurator.For(Guids.UnwittingMessangerBuff)
                .AddContextStatBonus(StatType.SkillUseMagicDevice, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillPersuasion, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();          
        }
    }
}
