using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class ShadowBlend
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateMasterfulTrick("ShadowBlend",
                                                    "ShadowBlend.Name",
                                                    "ShadowBlend.Description",
                                                    AbilityRefs.Displacement.Reference.Get().Icon,
                                                    Guids.ShadowBlend,
                                                    Guids.ShadowBlendAbility,
                                                    Guids.ShadowBlendBuff);

            BuffConfigurator.For(Guids.ShadowBlendBuff)
                .AddConcealment(false, false, Concealment.Total, ConcealmentDescriptor.Displacement)
                .Configure();
        }
    }
}
