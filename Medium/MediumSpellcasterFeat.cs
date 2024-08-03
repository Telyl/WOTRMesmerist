using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using BlueprintCore.Utils;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Items.Armors;
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.UnitLogic.Mechanics;
using Mesmerist.Medium.Archmage;
using Mesmerist.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mesmerist.Medium
{
    class MediumSpellcasterFeat
    {
        private static readonly string FeatName = "MediumSpellcasterFeat";

        public static void Configure()
        {
            ArchmageSpellbook.Configure();

            FeatureConfigurator.New(FeatName, Guids.MediumSpellcasterFeat)
                .AddSpellbook(ContextValues.Rank(), spellbook: Guids.ArchmageSpellbook)
                .AddSpellbook(ContextValues.Rank(), spellbook: Guids.HierophantSpellbook)
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(Guids.Medium).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .SetHideInUI(true)
                .SetHideNotAvailibleInUI(true)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetAllowNonContextActions(false)
                .Configure();

            FeatureConfigurator.New("ProhibitArchmageSpellbook", Guids.ProhibitArchmageSpellbook)
                .AddComponent<ForbidSpellbook>(c =>
                {
                    c.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(Guids.ArchmageSpellbook);
                })
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(Guids.Medium).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .SetHideInUI(true)
                .SetHideNotAvailibleInUI(true)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetAllowNonContextActions(false)
                .Configure();

            FeatureConfigurator.New("ProhibitHierophantSpellbook", Guids.ProhibitHierophantSpellbook)
                .AddComponent<ForbidSpellbook>(c =>
                {
                    c.m_Spellbook = BlueprintTool.GetRef<BlueprintSpellbookReference>(Guids.HierophantSpellbook);
                })
                .AddContextRankConfig(ContextRankConfigs.ClassLevel(new string[] { BlueprintTool.Get<BlueprintCharacterClass>(Guids.Medium).ToString() }, false, Kingmaker.Enums.AbilityRankType.Default, 20, 1))
                .SetHideInUI(true)
                .SetHideNotAvailibleInUI(true)
                .SetIsClassFeature(true)
                .SetReapplyOnLevelUp(false)
                .SetAllowNonContextActions(false)
                .Configure();
        }
    }
}