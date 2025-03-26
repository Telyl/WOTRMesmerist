using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class VanishArrow
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("VanishArrow",
                                           "VanishArrow.Name",
                                           "VanishArrow.Description",
                                           AbilityRefs.ProtectionFromArrows.Reference.Get().Icon,
                                           Guids.VanishArrow,
                                           Guids.VanishArrowAbility,
                                           Guids.VanishArrowBuff);

            BuffConfigurator.For(Guids.VanishArrowBuff)
                .AddDeflectArrows()
                .Configure();
        }
    }
}
