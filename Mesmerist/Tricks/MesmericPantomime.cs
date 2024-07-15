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
    public class MesmericPantomime
    {
        private static readonly string FeatName = "MesmericPantomime";
        internal const string DisplayName = "MesmericPantomime.Name";
        private static readonly string Description = "MesmericPantomime.Description";

        public static void Configure()
        {
            var Icon = AbilityRefs.BrilliantInspiration.Reference.Get().Icon;
            var BuffEffect = Guids.MesmericPantomimeBuffEffect;
            var ToggleBuff = Guids.MesmericPantomimeBuff;
            var Ability = Guids.MesmericPantomimeAbility;
            var Feat = Guids.MesmericPantomime;

            BuffConfigurator.New(FeatName + "BuffEffect", BuffEffect)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .AddContextStatBonus(StatType.SkillAthletics, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillMobility, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillThievery, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillStealth, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();

            TrickTools.CreateTrickToggleBuff(FeatName + "Buff", ToggleBuff, DisplayName, Description, Icon);
            TrickTools.CreateTrickActivatableAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, ToggleBuff);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
