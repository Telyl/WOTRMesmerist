using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Mesmerist.Utils;

namespace Mesmerist.Class.Mesmerist.Tricks
{
    internal class MesmericPantomime
    {
        public static void Configure()
        {
            CommonTrickHelpers.CreateTrick("MesmericPantomime",
                                          "MesmericPantomime.Name",
                                          "MesmericPantomime.Description",
                                          AbilityRefs.SignetOfHouseVespertilioAbilityAthletics.Reference.Get().Icon,
                                          Guids.MesmericPantomime,
                                          Guids.MesmericPantomimeAbility,
                                          Guids.MesmericPantomimeBuff);

            BuffConfigurator.For(Guids.MesmericPantomimeBuff)
                .AddContextStatBonus(StatType.SkillAthletics, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillMobility, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillThievery, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextStatBonus(StatType.SkillStealth, ContextValues.Rank(), ModifierDescriptor.Morale)
                .AddContextRankConfig(ContextRankConfigs.StatBonus(StatType.Charisma))
                .Configure();          
        }
    }
}
