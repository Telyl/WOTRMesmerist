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
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.NewComponents;
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
            var Icon = AbilityRefs.EarPiercingScream.Reference.Get().Icon;
            var TrickBuff = Guids.VoiceOfReasonBuff;
            var Ability = Guids.VoiceOfReasonAbility;
            var Feat = Guids.VoiceOfReason;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddTargetSavingThrowTrigger(ActionsBuilder.New().RemoveSelf(), onlyFail: true)
                .AddComponent<AddTargetSavingThrowTriggerMesmerist>(c =>
                {
                    c.OnlyFail = true;
                    c.SpecificSave = true;
                    c.ChooseSave = SavingThrowType.Will;
                    c.Action = ActionsBuilder.New().RemoveSelf().Build();
                })
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MindAffecting, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Compulsion, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
