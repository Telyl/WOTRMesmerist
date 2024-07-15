using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using Kingmaker.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using CharacterOptionsPlus.Util;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Mesmerist.NewComponents;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;

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
            var BuffEffectImproved = Guids.AstoundingAvoidanceBuffEffectImproved;
            var BuffEffect = Guids.AstoundingAvoidanceBuffEffect;
            var ToggleBuff = Guids.AstoundingAvoidanceBuff;
            var Ability = Guids.AstoundingAvoidanceAbility;
            var Feat = Guids.AstoundingAvoidance;

            BuffConfigurator.New(FeatName + "BuffEffectImproved", BuffEffectImproved)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddComponent<AddAstoundingAvoidanceTrick>(c => {
                    c.AstoundingAvoidanceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.AstoundingAvoidanceBuffEffectImproved);
                })
                .AddTemporaryFeat(FeatureRefs.ImprovedEvasion.Reference.Get())
                .Configure();

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddComponent<AddAstoundingAvoidanceTrick>(c => {
                    c.AstoundingAvoidanceBuff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.AstoundingAvoidanceBuffEffect);
                })
                .AddTemporaryFeat(FeatureRefs.Evasion.Reference.Get())
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
