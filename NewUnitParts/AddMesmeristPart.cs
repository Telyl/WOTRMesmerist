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
    [TypeId("621185caada448c5826583c5d29d4cd5")]
    public class AddMesmeristPart : UnitFactComponentDelegate<AddMesmeristPartData>
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(AddMesmeristPart));
        public BlueprintFeature ManifoldHijinks
        {
            get
            {
                BlueprintFeatureReference manifoldHijinks = this.m_ManifoldHijinks;
                if (manifoldHijinks == null)
                {
                    return null;
                }
                return manifoldHijinks.Get();
            }
        }  

        public override void OnActivate()
        {

        }
        public override void OnTurnOn()
        {
            base.OnTurnOn();
            if (!base.Data.Initialized && base.Owner.Get<UnitPartMesmerist>())
            {
                return;
            }
            base.Owner.Ensure<UnitPartMesmerist>();
            base.Owner.Ensure<UnitPartTricks>().Setup(this);
            base.Data.Initialized = true;
        }

        public override void OnPostLoad()
        {
            base.OnPostLoad();
            UnitPartTricks unitPartTricks = base.Owner.Get<UnitPartTricks>();
            if (unitPartTricks == null)
            {
                return;
            }
            unitPartTricks.Setup(this);
        }

                // Token: 0x0600CC34 RID: 52276 RVA: 0x003517A9 File Offset: 0x0034F9A9
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            if (base.Data.Initialized)
            {
                base.Owner.Remove<UnitPartMesmerist>();
                base.Owner.Remove<UnitPartTricks>();
                base.Data.Initialized = false;
            }
        }

        [SerializeField]
        [FormerlySerializedAs("ManifoldHijinks")]
        public BlueprintFeatureReference m_ManifoldHijinks;
        public BlueprintFeatureReference m_ManifoldTrick;
        public BlueprintBuffReference m_BouncingTrick;
        public BlueprintBuffReference m_ReapplyTrick;
    }
}
