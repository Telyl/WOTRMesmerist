using BlueprintCore.Blueprints.CustomConfigurators.Classes;
using BlueprintCore.Blueprints.References;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Buffs;
using Mesmerist.Utils;
using static UnityModManagerNet.UnityModManager.ModEntry;
using System;
using Kingmaker.Enums;
using BlueprintCore.Utils.Types;
using Kingmaker.Blueprints.Classes.Prerequisites;
using BlueprintCore.Blueprints.CustomConfigurators.Classes.Selection;
using Mesmerist.Mesmerist.Tricks;
using BlueprintCore.Blueprints.CustomConfigurators;
using Kingmaker.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using BlueprintCore.Blueprints.Configurators.UnitLogic.ActivatableAbilities;
using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using Kingmaker.UnitLogic.Mechanics.Components;
using Mesmerist.NewComponents;
using Mesmerist.NewUnitParts;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using System.Collections.Generic;

namespace Mesmerist.Mesmerist
{
    public class MesmeristTricks
    {
        private static readonly string FeatName = "MesmeristTricks";
        internal const string DisplayName = "MesmeristTrick.Name";
        private static readonly string Description = "MesmeristTrick.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            // Configure the Resource!
            BlueprintAbilityResource mtresource = AbilityResourceConfigurator.New(FeatName + "Resource", Guids.MesmeristTrickResource)
                .SetMaxAmount(new BlueprintAbilityResource.Amount
                {
                    BaseValue = 1,
                    IncreasedByLevel = false,
                    IncreasedByLevelStartPlusDivStep = true,
                    StartingLevel = 2,
                    StartingIncrease = 0,
                    LevelStep = 2,
                    PerStepIncrease = 1,
                    MinClassLevelIncrease = 0,
                    m_ClassDiv = [BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist)],
                    IncreasedByStat = true,
                    ResourceBonusStat = StatType.Charisma
                })
                .SetMax(10)
                .SetUseMax(false)
                .Configure();

            FeatureConfigurator.New(FeatName + "Feature", Guids.MesmeristTrickResourceFeature)
                .SetHideInUI(true)
                .AddComponent<AddMesmeristPart>(c =>
                {
                    c.m_Class = BlueprintTool.GetRef<BlueprintCharacterClassReference>(Guids.Mesmerist);
                    c.m_MaxTrick = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldTrick);
                    c.m_TrickResource = BlueprintTool.GetRef<BlueprintAbilityResourceReference>(Guids.MesmeristTrickResource);
                    c.m_PainfulStareCooldown = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.PainfulStareCooldown);
                    c.m_PainfulStare = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PainfulStare);
                    c.m_ManifoldStare = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldStarePainfulStare);
                    c.m_HypnoticStare = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.HypnoticStareBuff);
                    c.m_Tricks = 
                       [Guids.AstoundingAvoidanceBuff,
                        Guids.CompelAlacrityBuff,
                        Guids.CursedSanctionBuff,
                        Guids.FalseFlankerBuff ,
                        Guids.FearsomeGuiseBuff ,
                        Guids.FleetInShadowsBuff ,
                        Guids.FreeInBodyBuff ,
                        Guids.LevitationBufferBuff ,
                        Guids.LinkedReactionBuff ,
                        Guids.MeekFacadeBuff ,
                        Guids.MesmericMirrorBuff ,
                        Guids.MesmericPantomimeBuff ,
                        Guids.MisdirectionBuff ,
                        Guids.PsychosomaticSurgeBuff ,
                        Guids.ReflectFearBuff ,
                        Guids.SeeThroughInvisibilityBuff ,
                        Guids.ShadowSplinterBuff ,
                        Guids.SpectralSmokeAreaEffect ,
                        Guids.VanishArrowBuff ,
                        Guids.VoiceOfReasonBuff];
                    c.m_Stares = new BlueprintFeatureReference[] {
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Disorientation),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Disquiet),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Distracted),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Infiltration),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Lethality),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.ManifoldStare),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Nightmare),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PsychicInception),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.SappedMagic),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Sluggishness),
                        BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.Timidity),
                    };
                })
                .AddAbilityResources(resource: mtresource, restoreAmount: true, useThisAsResource: false)
                .Configure();

            FeatureSelectionConfigurator.New(FeatName + "Selection", Guids.MesmeristTrickSelection)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIcon(FeatureRefs.ArcanistExploits.Reference.Get().Icon)
                .SetIsClassFeature()
                .AddToAllFeatures([Guids.AstoundingAvoidance, Guids.CompelAlacrity, Guids.FalseFlanker,
                Guids.FearsomeGuise, Guids.FleetInShadows, Guids.LevitationBuffer,
                Guids.LinkedReaction, Guids.MeekFacade, Guids.MesmericMirror,
                Guids.MesmericPantomime, Guids.Misdirection, Guids.PsychosomaticSurge,
                Guids.ReflectFear, Guids.SeeThroughInvisibility, Guids.ShadowSplinter,
                Guids.SpectralSmoke, Guids.VanishArrow, Guids.VoiceOfReason, Guids.CursedSanction, Guids.FreeInBody])
                .Configure();

        }
    }
}
