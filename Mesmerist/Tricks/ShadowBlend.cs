﻿using BlueprintCore.Blueprints.CustomConfigurators.Classes;
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
using Kingmaker.Blueprints.Classes.Spells;
using Kingmaker.Designers.Mechanics.Facts;
using Kingmaker.EntitySystem.Stats;
namespace Mesmerist.Mesmerist.Tricks
{
    public class ShadowBlend
    {
        private static readonly string FeatName = "ShadowBlend";
        internal const string DisplayName = "ShadowBlend.Name";
        private static readonly string Description = "ShadowBlend.Description";

        public static void Configure()
        {

            var Icon = AbilityRefs.CamouflageAbility.Reference.Get().Icon;
            var TrickBuff = Guids.ShadowBlendBuff;
            var Ability = Guids.ShadowBlendAbility;
            var Feat = Guids.ShadowBlend;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddModifyD20(takeBest: true, rule: RuleType.SkillCheck,
                rollsAmount: 1, rerollOnlyIfFailed: true, dispellOnRerollFinished: true,
                skill: [StatType.SkillStealth])
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat, false, masterfulTrick: true);
            var feature = TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
            FeatureConfigurator.For(feature)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 12)
                .Configure();
        }
    }
}
