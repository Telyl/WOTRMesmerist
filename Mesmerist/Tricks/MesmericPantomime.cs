using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
namespace Mesmerist.Mesmerist.Tricks
{
    public class MesmericPantomime
    {
        private static readonly string FeatName = "MesmericPantomime";
        internal const string DisplayName = "MesmericPantomime.Name";
        private static readonly string Description = "MesmericPantomime.Description";

        public static void Configure()
        {
            var Icon = AbilityRefs.BrilliantInspiration.Reference.Get().Icon;
            var TrickBuff = Guids.MesmericPantomimeBuff;
            var Ability = Guids.MesmericPantomimeAbility;
            var Feat = Guids.MesmericPantomime;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddContextStatBonus(StatType.SkillAthletics, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillMobility, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillThievery, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillStealth, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .AddInitiatorSkillRollTrigger(true, StatType.SkillAthletics, ActionsBuilder.New().RemoveSelf())
                .AddInitiatorSkillRollTrigger(true, StatType.SkillMobility, ActionsBuilder.New().RemoveSelf())
                .AddInitiatorSkillRollTrigger(true, StatType.SkillThievery, ActionsBuilder.New().RemoveSelf())
                .AddInitiatorSkillRollTrigger(true, StatType.SkillStealth, ActionsBuilder.New().RemoveSelf())
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
