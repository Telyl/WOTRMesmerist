using CharacterOptionsPlus.Util;
using Kingmaker.Blueprints;
using Kingmaker.EntitySystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.Utility;
using Kingmaker.PubSubSystem;
using Kingmaker.UnitLogic.Class.Kineticist;
using Kingmaker.EntitySystem.Stats;
using System;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using System.Collections.Generic;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.ActivatableAbilities;
using System.Linq;
using Kingmaker.UnitLogic.Buffs;
using static Kingmaker.UI.CanvasScalerWorkaround;
using BlueprintCore.Utils;
using Mesmerist.Utils;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.RuleSystem.Rules.Damage;
using Kingmaker.Enums.Damage;
using Kingmaker.RuleSystem;
using Kingmaker;
using BlueprintCore.Actions.Builder;
using BlueprintCore.Utils.Types;
using Kingmaker.ElementsSystem;
using BlueprintCore.Actions.Builder.ContextEx;
using BlueprintCore.Blueprints.References;
using Kingmaker.UnitLogic.Mechanics.Components;
using HarmonyLib;
using Kingmaker.Controllers.Combat;
using static Kingmaker.RuleSystem.RulebookEvent;
using Mesmerist.Mesmerist.BoldStares;
using Mesmerist.Mesmerist;

namespace Mesmerist.NewUnitParts
{
    public class UnitPartMedium : OldStyleUnitPart,
        ISubscriber,
        IInitiatorRulebookSubscriber
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(UnitPartMedium));
        public EntityFact ArchmageSpirit => base.Owner.GetFact(this.settings.ArchmageSpirit);
        public EntityFact ChampionSpirit => base.Owner.GetFact(this.settings.ChampionSpirit);
        public EntityFact GuardianSpirit => base.Owner.GetFact(this.settings.GuardianSpirit);
        public EntityFact MarshalSpirit => base.Owner.GetFact(this.settings.MarshalSpirit);
        public EntityFact HierophantSpirit => base.Owner.GetFact(this.settings.HierophantSpirit);
        public EntityFact TricksterSpirit => base.Owner.GetFact(this.settings.TricksterSpirit);
        public int SpiritBonus
        {
            get
            {
                return Math.Max(0, base.Owner.Progression.Features.GetRank(this.settings.SpiritBonus));
            }
        }
        public void Setup(AddMediumPart settings)
        {
            this.settings = settings;
        }

        public StatType[] GetSpiritBonusInfo()
        {
            if (ArchmageSpirit != null)
            {
                return [StatType.SkillKnowledgeArcana, StatType.SkillKnowledgeWorld];
            }
            else if (ChampionSpirit != null)
            {
                return [StatType.AdditionalAttackBonus, StatType.AdditionalDamage,
                    StatType.SkillAthletics, StatType.SaveFortitude];
            }
            else if (GuardianSpirit != null)     
            {
                return [StatType.AC, StatType.SaveFortitude, StatType.SaveReflex];
            }
            else if (HierophantSpirit != null)
            {
                return [StatType.SaveWill, StatType.SkillLoreNature, 
                    StatType.SkillLoreReligion, StatType.SkillPerception];
            }
            else if (MarshalSpirit != null)
            {
                return [StatType.SkillPersuasion, StatType.SkillUseMagicDevice];
            }
            else if (TricksterSpirit != null)
            {
                return [StatType.SkillThievery, StatType.SkillStealth,
                    StatType.SkillMobility, StatType.SaveReflex];
            }
            return null;
        }
        public EntityFact GetActiveSpirit()
        {
            if (ArchmageSpirit != null)
            {
                return ArchmageSpirit;
            }
            else if (ChampionSpirit != null)
            {
                return ChampionSpirit;
            }
            else if (GuardianSpirit != null)
            {
                return GuardianSpirit;
            }
            else if (HierophantSpirit != null)
            {
                return HierophantSpirit;    
            }
            else if (MarshalSpirit != null)
            {
                return MarshalSpirit;
            }
            else if (TricksterSpirit != null)
            {
                return TricksterSpirit;
            }
            return null;
        }
        private AddMediumPart settings;
    }
}
