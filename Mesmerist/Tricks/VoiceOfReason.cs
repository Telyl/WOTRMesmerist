using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.Blueprints.Classes.Spells;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
namespace Mesmerist.Mesmerist.Tricks
{
    public class VoiceOfReason
    {
        private static readonly string FeatName = "VoiceOfReason";
        internal const string DisplayName = "VoiceOfReason.Name";
        private static readonly string Description = "VoiceOfReason.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.VoiceOfReasonBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetIcon(AbilityRefs.EarPiercingScream.Reference.Get().Icon)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MindAffecting, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Compulsion, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();

            BuffConfigurator.New(FeatName + "Buff", Guids.VoiceOfReasonBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.EarPiercingScream.Reference.Get().Icon)
                .SetFlags(Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff.Flags.HiddenInUi)
                .Configure();

            ActivatableAbilityConfigurator.New(FeatName + "Ability", Guids.VoiceOfReasonAbility)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(AbilityRefs.EarPiercingScream.Reference.Get().Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(Guids.VoiceOfReasonBuff)
                 .SetDeactivateImmediately()
                 .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.VoiceOfReason)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Guids.VoiceOfReasonAbility })
                .SetIsClassFeature()
                .Configure();


        }
    }
}
