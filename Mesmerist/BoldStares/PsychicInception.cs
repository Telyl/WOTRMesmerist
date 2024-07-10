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
using Kingmaker.UnitLogic.FactLogic;
using Kingmaker.Blueprints.Classes.Spells;
using CharacterOptionsPlus.Util;
using Mesmerist.NewComponents;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using BlueprintCore.Blueprints.CustomConfigurators.UnitLogic.Abilities;
using TabletopTweaks.Core.Utilities;
using Kingmaker.Blueprints;
using BlueprintCore.Utils;
using Kingmaker.UnitLogic.Mechanics.Actions;
using System.Linq;
using Kingmaker.Utility;
using Kingmaker.UnitLogic.Abilities.Components;

namespace Mesmerist.Mesmerist.BoldStares
{
    public class PsychicInception
    {
        private static readonly string FeatName = "PsychicInception";
        internal const string DisplayName = "PsychicInception.Name";
        private static readonly string Description = "PsychicInception.Description";

        private static readonly Logging.Logger Logger = Logging.GetLogger(FeatName);

        public static void Configure()
        {
            BuffConfigurator.New(FeatName + "Buff", Guids.PsychicInceptionBuff)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .AddUniqueBuff()
                .AddComponent<AddPsychicInceptionSpells>(c =>
                {
                    c.IgnoreDescriptors = SpellDescriptor.MindAffecting | SpellDescriptor.Charm | SpellDescriptor.Compulsion;
                    c.BecauseOfFact = BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.PsychicInception);
                    c.BecauseOfFactBuff = BlueprintTool.GetRef<BlueprintBuffReference>(Guids.HypnoticStareBuff);
                })
                .SetIcon(BuffRefs.DebilitatingInjuryDisorientedEffectBuff.Reference.Get().Icon)
                .Configure();

            //TODO: Change CharacterLevel to ClassLevel(Mesmerist)
            FeatureConfigurator.New(FeatName, Guids.PsychicInception)
                .SetDisplayName(DisplayName)
                .SetDescription(Description)
                .SetIsClassFeature()
                .Configure();

        }
    }
}
