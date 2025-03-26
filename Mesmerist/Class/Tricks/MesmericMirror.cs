using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.UnitLogic.Buffs.Components;
using Mesmerist.Utils;

namespace Mesmerist.Class.Tricks
{
    internal class MesmericMirror
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("MesmericMirror",
                                          "MesmericMirror.Name",
                                          "MesmericMirror.Description",
                                          AbilityRefs.MirrorImage.Reference.Get().Icon,
                                          Guids.MesmericMirror,
                                          Guids.MesmericMirrorAbility,
                                          Guids.MesmericMirrorBuff);

            BuffConfigurator.For(Guids.MesmericMirrorBuff)
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(AddMirrorImage))
                .CopyFrom(BuffRefs.MirrorImageBuff.Reference.Get(), typeof(ContextRankConfigs))
                .Configure();
        }
    }
}
