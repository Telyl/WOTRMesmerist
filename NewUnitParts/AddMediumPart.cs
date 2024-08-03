using System;
using System.Collections.Generic;
using System.Linq;
using BlueprintCore.Blueprints.References;
using CharacterOptionsPlus.Util;
using Kingmaker;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Facts;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.EntitySystem.Entities;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.RuleSystem.Rules;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Buffs;
using Kingmaker.UnitLogic.Buffs.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using Owlcat.QA.Validation;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mesmerist.NewUnitParts
{
    // Token: 0x02001D72 RID: 7538
    [AllowedOn(typeof(BlueprintUnitFact), false)]
    [TypeId("5c5a28a8c6654b58a676cb9441c3e608")]
    public class AddMediumPart : UnitFactComponentDelegate<AddMediumPartData>
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddMediumPart));
        public BlueprintFeature ArchmageSpirit => m_ArchmageSpirit.Get();
        public BlueprintFeature ChampionSpirit => m_ChampionSpirit.Get();
        public BlueprintFeature GuardianSpirit => m_GuardianSpirit.Get();
        public BlueprintFeature MarshalSpirit => m_MarshalSpirit.Get();
        public BlueprintFeature HierophantSpirit => m_HierophantSpirit.Get();
        public BlueprintFeature TricksterSpirit => m_TricksterSpirit.Get();
        public BlueprintFeature SpiritBonus => m_SpiritBonus.Get();
        public override void OnActivate()
        {

        }
        public override void OnTurnOn()
        {
            base.OnTurnOn();
            if (!base.Data.Initialized && base.Owner.Get<UnitPartMedium>())
            {
                return;
            }
            base.Owner.Ensure<UnitPartMedium>().Setup(this);
            base.Data.Initialized = true;
        }

        public override void OnPostLoad()
        {
            base.OnPostLoad();
            UnitPartMedium unitPartMedium = base.Owner.Get<UnitPartMedium>();
            if (unitPartMedium == null)
            {
                return;
            }
            unitPartMedium.Setup(this);
        }

        // Token: 0x0600CC34 RID: 52276 RVA: 0x003517A9 File Offset: 0x0034F9A9
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            if (base.Data.Initialized)
            {
                base.Owner.Remove<UnitPartMedium>();
                base.Data.Initialized = false;
            }
        }

        private BlueprintFeatureReference m_ArchmageSpirit;
        private BlueprintFeatureReference m_ChampionSpirit;
        private BlueprintFeatureReference m_GuardianSpirit;
        private BlueprintFeatureReference m_MarshalSpirit;
        private BlueprintFeatureReference m_HierophantSpirit;
        private BlueprintFeatureReference m_TricksterSpirit;
        private BlueprintFeatureReference m_SpiritBonus;
    }
}
