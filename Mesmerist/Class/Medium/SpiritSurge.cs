using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Mesmerist.Utils;

namespace Mesmerist.Class.Medium
{
    internal class SpiritSurge
    {
        private static readonly string FeatName = "SpiritSurge";
        internal const string DisplayName = "SpiritSurge.Name";
        private static readonly string Description = "SpiritSurge.Description";
        public static void Configure()
        {
            var buffD10 = BuffConfigurator.New(FeatName + "BuffD10", Guids.SpiritSurgeBuffD10)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.DazeBuff.Reference.Get().Icon)
                .Configure();

            var buffD8 = BuffConfigurator.New(FeatName + "BuffD8", Guids.SpiritSurgeBuffD8)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.GuidanceBuff.Reference.Get().Icon)
                .Configure();

            var buff = BuffConfigurator.New(FeatName + "Buff", Guids.SpiritSurgeBuffD6)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.EldritchFontGreaterSurgeBuff.Reference.Get().Icon)
                .Configure();

            AbilityConfigurator.New(FeatName + "Ability", Guids.SpiritSurgeAbility)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.EldritchFontGreaterSurgeBuff.Reference.Get().Icon)
                .AddAbilityEffectRunAction(ActionsBuilder.New().Conditional(ConditionsBuilder.New().BuffRank(useFactInsteadBuff: true, rankValue: 3, fact: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.SpiritSurge)), 
                    ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buffD10),
                    ifFalse: ActionsBuilder.New().Conditional(ConditionsBuilder.New().BuffRank(useFactInsteadBuff: true, rankValue: 2, fact: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.SpiritSurge)), 
                        ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buffD8),
                        ifFalse: ActionsBuilder.New().Conditional(ConditionsBuilder.New().BuffRank(useFactInsteadBuff: true, rankValue: 1, fact: BlueprintTool.GetRef<BlueprintUnitFactReference>(Guids.SpiritSurge)), 
                            ifTrue: ActionsBuilder.New().ApplyBuffPermanent(buff)))))
                .Configure();

            FeatureConfigurator.New(FeatName, Guids.SpiritSurge)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.EldritchFontGreaterSurgeBuff.Reference.Get().Icon)
                .SetRanks(3)
                .AddFacts(new() { Guids.SpiritSurgeAbility })
                .Configure();
        }
    }
}
