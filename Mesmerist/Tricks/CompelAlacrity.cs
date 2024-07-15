using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using static Kingmaker.UnitLogic.Commands.Base.UnitCommand;
using Kingmaker.UnitLogic.Abilities.Components;
using Kingmaker.UnitLogic.Abilities.Components.TargetCheckers;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;

namespace Mesmerist.Mesmerist.Tricks
{
    public class CompelAlacrity
    {
        private static readonly string FeatName = "CompelAlacrity";
        internal const string DisplayName = "CompelAlacrity.Name";
        private static readonly string Description = "CompelAlacrity.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.DimensionDoor.Reference.Get().Icon;
            var BuffEffect = Guids.CompelAlacrityBuffEffect;
            var ToggleBuff = Guids.CompelAlacrityBuff;
            var Ability = Guids.CompelAlacrityAbility;
            var Feat = Guids.CompelAlacrity;

            AbilityConfigurator.New(FeatName + "DimensionDoorAbility", Guids.CompelAlacrityDimensionDoorAbility)
                .CopyFrom(AbilityRefs.DimensionDoor.Reference.Get(),typeof(AbilityCustomDimensionDoor))
                .CopyFrom(AbilityRefs.DimensionDoor.Reference.Get(),typeof(LineOfSightIgnorance))
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetActionType(CommandType.Swift)
                .SetCanTargetPoint(true)
                .SetCanTargetEnemies(true)
                .SetRange(AbilityRange.Close)
                .Configure();

            FeatureConfigurator.New(FeatName + "DimensionDoorFeat", Guids.CompelAlacrityDimensionDoorFeat)
                .AddFacts(new() { Guids.CompelAlacrityDimensionDoorAbility })
                .SetHideInUI()
                .Configure();

            // Add Temporary Feature - Dimensions Door
            BuffConfigurator.New(FeatName + "BuffEffect", Guids.CompelAlacrityBuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(AbilityRefs.ExpeditiousRetreat.Reference.Get().Icon)
                .AddTemporaryFeat(Guids.CompelAlacrityDimensionDoorFeat)
                .AddRemoveWhenCombatEnded()
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
