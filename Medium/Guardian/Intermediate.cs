using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils.Types;
using CharacterOptionsPlus.Util;
using Kingmaker.Enums.Damage;
using Mesmerist.Utils;

namespace Mesmerist.Medium.Guardian
{
    public class GuardianIntermediate
    {
        private static readonly string FeatName = "GuardianIntermediate";
        internal const string DisplayName = "GuardianIntermediate.Name";
        private static readonly string Description = "GuardianIntermediate.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);
        public static void Configure()
        {
            FeatureConfigurator.New(FeatName, Guids.GuardianIntermediate)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddDamageResistancePhysical(value: ContextValues.Rank())
                .AddDamageResistanceEnergy(type: DamageEnergyType.Fire | DamageEnergyType.Cold | 
                DamageEnergyType.Sonic | DamageEnergyType.Acid | DamageEnergyType.Electricity |
                DamageEnergyType.Holy | DamageEnergyType.Unholy | DamageEnergyType.Divine | 
                DamageEnergyType.Magic, value: ContextValues.Rank())
                .AddContextRankConfig(ContextRankConfigs.ClassLevel([Guids.Medium]).WithDiv2Progression())
                .Configure();
        }
    }
}
