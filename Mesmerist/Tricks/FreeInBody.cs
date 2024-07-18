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
namespace Mesmerist.Mesmerist.Tricks
{
    public class FreeInBody
    {
        private static readonly string FeatName = "FreeInBody";
        internal const string DisplayName = "FreeInBody.Name";
        private static readonly string Description = "FreeInBody.Description";




        public static void Configure()
        {

            var Icon = AbilityRefs.FreedomOfMovement.Reference.Get().Icon;
            var TrickBuff = Guids.FreeInBodyBuff;
            var Ability = Guids.FreeInBodyAbility;
            var Feat = Guids.FreeInBody;

            TrickTools.CreateTrickTrickBuff(FeatName + "Buff", TrickBuff, DisplayName, Description, Icon);
            BuffConfigurator.For(TrickBuff)
                .AddRemoveWhenCombatEnded()
                .AddFacts(new() { BuffRefs.FreedomOfMovementBuff.Reference.Get() })
                .Configure();
            TrickTools.CreateTrickAbility(FeatName + "Ability", Ability, DisplayName, Description, Icon, TrickBuff, Feat, false);
            
            var feature = TrickTools.CreateTrickFeature(FeatName, Feat, DisplayName, Description, Ability);
            FeatureConfigurator.For(feature)
                .AddPrerequisiteClassLevel(Guids.Mesmerist, 12)
                .Configure();
        }
    }
}
