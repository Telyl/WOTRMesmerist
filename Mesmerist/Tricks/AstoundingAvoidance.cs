using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using CharacterOptionsPlus.Util;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Mesmerist.NewComponents.AbilitySpecific;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Conditions.Builder.ContextEx;
using static Kingmaker.UnitLogic.Mechanics.Conditions.ContextConditionInContext;

namespace Mesmerist.Mesmerist.Tricks
{
    public class AstoundingAvoidance
    {
        private static readonly string FeatName = "AstoundingAvoidance";
        internal const string DisplayName = "AstoundingAvoidance.Name";
        private static readonly string Description = "AstoundingAvoidance.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = FeatureRefs.Evasion.Reference.Get().Icon;
            var TrickBuff = Guids.AstoundingAvoidanceBuff;
            var Ability = Guids.AstoundingAvoidanceAbility;
            var Feat = Guids.AstoundingAvoidance;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);

            BuffConfigurator.For(TrickBuff)
                .AddComponent<AddAstoundingAvoidanceTrick>(c => {
                    c.AstoundingAvoidance = BlueprintTool.GetRef<BlueprintBuffReference>(TrickBuff);
                })
                .AddTemporaryFeat(FeatureRefs.Evasion.Reference.Get())
                .Configure();

            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
