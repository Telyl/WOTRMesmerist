using BlueprintCore.Actions.Builder;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.Mechanics.Components;
using Kingmaker.Utility;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class SeeInDarkness
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("SeeInDarkness",
                                           "SeeInDarkness.Name",
                                           "SeeInDarkness.Description",
                                           AbilityRefs.Echolocation.Reference.Get().Icon,
                                           Guids.SeeInDarkness,
                                           Guids.SeeInDarknessAbility,
                                           Guids.SeeInDarknessBuff);

            BuffConfigurator.For(Guids.SeeInDarknessBuff)
                .AddBlindsense(30.Feet(), true)
                .Configure();
        }
    }
}
