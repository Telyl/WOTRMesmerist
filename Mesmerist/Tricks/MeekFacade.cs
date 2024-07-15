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
namespace Mesmerist.Mesmerist.Tricks
{
    public class MeekFacade
    {
        private static readonly string FeatName = "MeekFacade";
        internal const string DisplayName = "MeekFacade.Name";
        private static readonly string Description = "MeekFacade.Description";

        public static void Configure()
        {
            var Icon = AbilityRefs.ReducePerson.Reference.Get().Icon;
            var BuffEffect = Guids.MeekFacadeBuffEffect;
            var ToggleBuff = Guids.MeekFacadeBuff;
            var Ability = Guids.MeekFacadeAbility;
            var Feat = Guids.MeekFacade;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddRemoveWhenCombatEnded()
                .SetIcon(Icon)
                .AddContextStatBonus(StatType.AC, ContextValues.Rank(), ModifierDescriptor.Dodge)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel(AbilityRankType.Default).WithCustomProgression((4, 2), (9, 3), (14,4), (19,5), (20,6)))
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
