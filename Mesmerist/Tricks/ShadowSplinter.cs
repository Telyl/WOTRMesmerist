using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
namespace Mesmerist.Mesmerist.Tricks
{
    public class ShadowSplinter
    {
        private static readonly string FeatName = "ShadowSplinter";
        internal const string DisplayName = "ShadowSplinter.Name";
        private static readonly string Description = "ShadowSplinter.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.ShadowEvocation.Reference.Get().Icon;
            var TrickBuff = Guids.ShadowSplinterBuff;
            var Ability = Guids.ShadowSplinterAbility;
            var Feat = Guids.ShadowSplinter;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddPlayerLeaveCombatTrigger(ActionsBuilder.New().RemoveSelf())
                .AddDamageResistancePhysical(value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma, ModifierDescriptor.UntypedStackable, min: 1))
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
