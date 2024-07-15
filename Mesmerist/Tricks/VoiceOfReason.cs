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
            var Icon = AbilityRefs.EarPiercingScream.Reference.Get().Icon;
            var BuffEffect = Guids.VoiceOfReasonBuffEffect;
            var ToggleBuff = Guids.VoiceOfReasonBuff;
            var Ability = Guids.VoiceOfReasonAbility;
            var Feat = Guids.VoiceOfReason;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.MindAffecting, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Charm, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddSavingThrowBonusAgainstDescriptor(spellDescriptor: SpellDescriptor.Compulsion, modifierDescriptor: ModifierDescriptor.Insight, bonus: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
