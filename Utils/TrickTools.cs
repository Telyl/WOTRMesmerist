using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Kingmaker.Blueprints.Classes;
using Kingmaker.ElementsSystem;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Mesmerist.NewComponents;
using static TabletopTweaks.Core.MechanicsChanges.AdditionalActivatableAbilityGroups;

namespace Mesmerist.Utils
{
    public class TrickTools
    {
        public static BlueprintBuff CreateTrickToggleBuff(string FeatName, string GUID,
            string DisplayName, string Description, UnityEngine.Sprite Icon)
        {
            return BuffConfigurator.New(FeatName, GUID)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(Icon)
                .SetFlags(BlueprintBuff.Flags.HiddenInUi)
                .Configure();
        }

        public static BlueprintActivatableAbility CreateTrickActivatableAbility(string FeatName, string GUID,
            string DisplayName, string Description, UnityEngine.Sprite Icon, string TrickBuff)
        {
            return ActivatableAbilityConfigurator.New(FeatName, GUID)
                 .SetDisplayName(DisplayName)
                 .SetDescription(Description)
                 .SetIcon(Icon)
                 .SetGroup((ActivatableAbilityGroup)((ExtentedActivatableAbilityGroup)1819))
                 .SetHiddenInUI()
                 .SetBuff(TrickBuff)
                 .SetDeactivateImmediately()
                 .Configure();
        }

        public static BlueprintFeature CreateTrickFeature(string FeatName, string GUID, 
            string DisplayName, string Description, string Facts)
        {
            return FeatureConfigurator.New(FeatName, GUID)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddFacts(new() { Facts })
                .SetIsClassFeature()
                .Configure();
        }
    }
}
