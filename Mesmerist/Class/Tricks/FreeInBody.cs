using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class FreeInBody
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateMasterfulTrick("FreeInBody",
                                                    "FreeInBody.Name",
                                                    "FreeInBody.Description",
                                                    AbilityRefs.FreedomOfMovement.Reference.Get().Icon,
                                                    Guids.FreeInBody,
                                                    Guids.FreeInBodyAbility,
                                                    Guids.FreeInBodyBuff);

            BuffConfigurator.For(Guids.FreeInBodyBuff)
                .AddFacts(new() { BuffRefs.FreedomOfMovementBuff.Reference.Get() })
                .Configure();
        }
    }
}
