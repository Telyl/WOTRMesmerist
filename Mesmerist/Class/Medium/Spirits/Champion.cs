using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.BasicEx;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;
using static Kingmaker.UnitLogic.Buffs.Blueprints.BlueprintBuff;

namespace Mesmerist.Class.Medium.Spirits
{
    internal class Champion
    {
        private static readonly string FeatName = "Champion";
        internal const string DisplayName = "Champion.Name";
        private static readonly string Description = "Champion.Description";

        private static readonly string BUFF = Guids.ChampionBuff;
        private static readonly string ABILITY = Guids.ChampionActivatableAbility;
        private static readonly string FEATURE = Guids.Champion;
        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Supreme", Guids.ChampionSupreme)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.FlameShieldBuff.Reference.Get().Icon)
                .AddContextStatBonus(stat: StatType.BaseAttackBonus, value: ContextValues.Rank(), descriptor: ModifierDescriptor.None, minimal: 1)
                .AddContextRankConfig(ContextRankConfigs.CharacterLevel().WithStartPlusDivStepProgression(4,4))
                .Configure();

            BuffConfigurator.New(FeatName + "Greater", Guids.ChampionGreater)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.HealingJudgmentBuff.Reference.Get().Icon)
                .AddFacts(new() { FeatureRefs.Pounce.Reference.Get() })
                .Configure();

            BuffConfigurator.New(FeatName + "Intermediate", Guids.ChampionIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.DazeBuff.Reference.Get().Icon)
                .AddBuffExtraAttack(haste: false, number: 1, penalized: false)
                .Configure();

            BuffConfigurator.New(FeatName + "Lesser", Guids.ChampionLesser)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(BuffRefs.GuidanceBuff.Reference.Get().Icon)
                .AddFacts(new() { FeatureRefs.MartialWeaponProficiency.Reference.Get(),
                    FeatureRefs.BastardSwordProficiency.Reference.Get(),
                    FeatureRefs.DuelingSwordProficiency.Reference.Get(),
                    FeatureRefs.DwarvenWeaponFamiliarity.Reference.Get(),
                    FeatureRefs.ElvenCurvedBladeProficiency.Reference.Get(),
                    FeatureRefs.EstocProficiency.Reference.Get(),
                    FeatureRefs.FalcataProficiency.Reference.Get(),
                    FeatureRefs.FauchardProficiency.Reference.Get(),
                    FeatureRefs.HookedHammerProficiency.Reference.Get(),
                    FeatureRefs.KamaProficiency.Reference.Get(),
                    FeatureRefs.NunchakuProficiency.Reference.Get(),
                    FeatureRefs.DoubleAxeProficiency.Reference.Get(),
                    FeatureRefs.SaiProficiency.Reference.Get(),
                    FeatureRefs.SlingStaffProficiency.Reference.Get(),
                    FeatureRefs.StarknifeProficiency.Reference.Get(),
                    FeatureRefs.TongiProficiency.Reference.Get(),
                    FeatureRefs.UrgroshProficiency.Reference.Get(),
                    FeatureRefs.DoubleSwordProficiency.Reference.Get() })
                .Configure();

            var buff = BuffConfigurator.New(FeatName + "Buff", BUFF)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetFlags(Flags.HiddenInUi)
                .AddBuffActions(activated: ActionsBuilder.New().ApplyBuffPermanent(Guids.ChampionLesser)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerIntermediate), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ChampionIntermediate)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerGreater), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ChampionGreater)
                    .Conditional(ConditionsBuilder.New().CasterHasFact(Guids.SpiritPowerSupreme), ifTrue: ActionsBuilder.New().ApplyBuffPermanent(Guids.ChampionSupreme)))))
                .Configure();

            var ability = ActivatableAbilityConfigurator.New(FeatName + "ActivatableAbility", ABILITY)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetDeactivateImmediately()
                .SetBuff(buff)
                .Configure();

            var feature = FeatureConfigurator.New(FeatName, FEATURE)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature(true)
                .AddFacts(new() { ability })
                .Configure();
        }
    }
}
