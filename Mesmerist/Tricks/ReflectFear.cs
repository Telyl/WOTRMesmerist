using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using CharacterOptionsPlus.Util;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using Kingmaker.UnitLogic.ActivatableAbilities;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;
using Kingmaker.UnitLogic.Abilities;
using Kingmaker.Utility;
using System.Drawing;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Components;
using BlueprintCore.Conditions.Builder;
using BlueprintCore.Conditions.Builder.ContextEx;
using Mesmerist.NewComponents;
namespace Mesmerist.Mesmerist.Tricks
{
    public class ReflectFear
    {
        private static readonly string FeatName = "ReflectFear";
        internal const string DisplayName = "ReflectFear.Name";
        private static readonly string Description = "ReflectFear.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            var Icon = AbilityRefs.Fear.Reference.Get().Icon;
            var TrickBuff = Guids.ReflectFearBuff;
            var Ability = Guids.ReflectFearAbility;
            var Feat = Guids.ReflectFear;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                //.AddTargetSavingThrowTrigger()
                .AddComponent<AddInitiatorSavingThrowTriggerMesmerist>(c=>
                {
                    c.SpecificSave = true;
                    c.ChooseSave = SavingThrowType.Will;
                    c.OnlyFail = true;
                    c.Action = ActionsBuilder.New().RemoveSelf().Build();
                    c.ActOnInitiator = true;
                    c.ActionsOnInitiator = ActionsBuilder.New().CastSpell(AbilityRefs.Castigate.Reference.Get()).Build();
                })
                // Need to create a condition checker that lets me tell what saving throw type it is.
                // Once I know that, we say, "On a will save that's been failed, remove self"
                // Then apply "fear" on the target.
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat);
            TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
        }
    }
}
