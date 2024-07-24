using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.Blueprints;
using Mesmerist.NewComponents;
using Kingmaker.Designers.EventConditionActionSystem.Actions;
using static HarmonyLib.Code;
using static Kingmaker.EntitySystem.EntityDataBase;
namespace Mesmerist.Mesmerist.Tricks
{
    public class GoodHope
    {
        private static readonly string FeatName = "GoodHopeTrick";
        internal const string DisplayName = "GoodHopeTrick.Name";
        private static readonly string Description = "GoodHopeTrick.Description";




        public static void Configure()
        {

            var Icon = AbilityRefs.GoodHope.Reference.Get().Icon;
            var TrickBuff = Guids.GoodHopeTrickBuff;
            var Ability = Guids.GoodHopeTrickAbility;
            var Feat = Guids.GoodHopeTrick;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Morale, false, Kingmaker.EntitySystem.Stats.StatType.AdditionalAttackBonus, 2)
                .AddStatBonus(Kingmaker.Enums.ModifierDescriptor.Morale, false, Kingmaker.EntitySystem.Stats.StatType.AdditionalDamage, 2)
                .AddBuffAllSavesBonus(Kingmaker.Enums.ModifierDescriptor.Morale, 2)
                .AddBuffAllSkillsBonus(Kingmaker.Enums.ModifierDescriptor.Morale, 2)
                .AddBuffAbilityRollsBonus(true, Kingmaker.Enums.ModifierDescriptor.Morale, value: 2)
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat, false, masterfulTrick: true);
            var feature = TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
            FeatureConfigurator.For(feature)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 12)
                .Configure();
        }
    }
}
