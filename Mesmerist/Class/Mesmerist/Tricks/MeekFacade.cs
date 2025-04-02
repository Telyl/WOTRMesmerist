using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class MeekFacade
    {
        private static readonly string FeatName = "MeekFacade";
        internal const string DisplayName = "MeekFacade.Name";
        private static readonly string Description = "MeekFacade.Description";

        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("MeekFacade",
                                          "MeekFacade.Name",
                                          "MeekFacade.Description",
                                          AbilityRefs.Grace.Reference.Get().Icon,
                                          Guids.MeekFacade,
                                          Guids.MeekFacadeAbility,
                                          Guids.MeekFacadeBuff);

            BuffConfigurator.For(Guids.MeekFacadeBuff)
                .AddContextStatBonus(StatType.AC, ContextValues.Rank(), ModifierDescriptor.Dodge)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Mesmerist], type: AbilityRankType.Default).WithCustomProgression((4, 2), (9, 3), (14, 4), (19, 5), (20, 6)))
                .Configure();
        }
    }
}
