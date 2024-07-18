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
        public BlueprintCharacterClass Class
        {
            get
            {
                BlueprintCharacterClassReference @class = this.m_Class;
                if (@class == null)
                {
                    return null;
                }
                return @class.Get();
            }
        }
        public BlueprintFeature MaxTrick
        {
            get
            {
                BlueprintFeatureReference maxTrick = this.m_MaxTrick;
                if (maxTrick == null)
                {
                    return null;
                }
                return maxTrick.Get();
            }
        }
        public BlueprintAbilityResource TrickResource
        {
            get
            {
                BlueprintAbilityResourceReference trickResource = this.m_TrickResource;
                if (trickResource == null)
                {
                    return null;
                }
                return trickResource.Get();
            }
        }
        public BlueprintBuff HypnoticStare
        {
            get
            {
                BlueprintBuffReference hypnoticStare = this.m_HypnoticStare;
                if (hypnoticStare == null)
                {
                    return null;
                }
                return hypnoticStare.Get();
            }
        }
        public BlueprintBuff PainfulStareCooldown
        {
            get
            {
                BlueprintBuffReference painfulStareCooldown = this.m_PainfulStareCooldown;
                if (painfulStareCooldown == null)
                {
                    return null;
                }
                return painfulStareCooldown.Get();
            }
        }
        public BlueprintFeature PainfulStare
        {
            get
            {
                BlueprintFeatureReference painfulStare = this.m_PainfulStare;
                if (painfulStare == null)
                {
                    return null;
                }
                return painfulStare.Get();
            }
        }
        public BlueprintFeature ManifoldStare
        {
            get
            {
                BlueprintFeatureReference manifoldStare = this.m_ManifoldStare;
                if (manifoldStare == null)
                {
                    return null;
                }
                return manifoldStare.Get();
            }
        }
        public string[] Tricks
        {
            get
            {
                return this.m_Tricks;
            }
        }

        public ReferenceArrayProxy<BlueprintFeature, BlueprintFeatureReference> Stares
        {
            get
            {
                return this.m_Stares;
            }
        }

        public override void OnActivate()
        {

        }

                // Token: 0x0600CC32 RID: 52274 RVA: 0x0035170C File Offset: 0x0034F90C
        public override void OnTurnOn()
        {
            base.OnTurnOn();
            if (!base.Data.Initialized && base.Owner.Get<UnitPartMesmerist>())
            {
                return;
            }
            base.Owner.Ensure<UnitPartMesmerist>().Setup(this);
            base.Data.Initialized = true;
        }

        public override void OnPostLoad()
        {
            base.OnPostLoad();
            UnitPartMesmerist unitPartMesmerist = base.Owner.Get<UnitPartMesmerist>();
            if (unitPartMesmerist == null)
            {
                return;
            }
            unitPartMesmerist.Setup(this);
            unitPartMesmerist.CleanupTrackedTricks();

            foreach (Buff buff in base.Owner.Descriptor.Buffs)
            {
                if (Tricks.Contains(buff.Blueprint.AssetGuid.ToString()))
                {
                    unitPartMesmerist.AddTrick(base.Owner, buff);
                }
            }
            foreach (UnitEntityData unitEntityData in Game.Instance.Player.ActiveCompanions)
            {
                foreach (Buff buff in unitEntityData.Descriptor.Buffs)
                {
                    if (Tricks.Contains(buff.Blueprint.AssetGuid.ToString()))
                    {
                        unitPartMesmerist.AddTrick(unitEntityData, buff);
                    }
                }
            }
        }

                // Token: 0x0600CC34 RID: 52276 RVA: 0x003517A9 File Offset: 0x0034F9A9
        public override void OnDeactivate()
        {
            base.OnDeactivate();
            if (base.Data.Initialized)
            {
                base.Owner.Remove<UnitPartMesmerist>();
                base.Data.Initialized = false;
            }
        }
        
        // Token: 0x0600CC35 RID: 52277 RVA: 0x003517D8 File Offset: 0x0034F9D8
        [Obsolete]
        public override void ApplyValidation(ValidationContext context, int parentIndex)
        {
            base.ApplyValidation(context, parentIndex);
            if (!this.Class)
            {
                context.AddError("Class is missing", Array.Empty<object>());
            }
            if (!this.MaxTrick)
            {
                context.AddError("MaxTrick is missing", Array.Empty<object>());
            }
            if (!this.TrickResource)
            {
                context.AddError("TrickResource is missing", Array.Empty<object>());
            }
        }

        // Token: 0x040087C7 RID: 34759
        [SerializeField]
        [FormerlySerializedAs("Class")]
        public BlueprintCharacterClassReference m_Class;

        // Token: 0x040087C9 RID: 34761
        [SerializeField]
        [FormerlySerializedAs("MaxTrick")]
        public BlueprintFeatureReference m_MaxTrick;

        // Token: 0x040087CB RID: 34763
        [SerializeField]
        [FormerlySerializedAs("TrickResource")]
        public BlueprintAbilityResourceReference m_TrickResource;

        [SerializeField]
        [FormerlySerializedAs("PainfulStareCooldown")]
        public BlueprintBuffReference m_PainfulStareCooldown;

        [SerializeField]
        [FormerlySerializedAs("PainfulStare")]
        public BlueprintFeatureReference m_PainfulStare;

        [SerializeField]
        [FormerlySerializedAs("PainfulStareCooldown")]
        public BlueprintFeatureReference m_ManifoldStare;

        [SerializeField]
        [FormerlySerializedAs("HypnoticStare")]
        public BlueprintBuffReference m_HypnoticStare;

        // Token: 0x040087D0 RID: 34768
        [SerializeField]
        [FormerlySerializedAs("Tricks")]
        public string[] m_Tricks = new string[0];

        [SerializeField]
        [FormerlySerializedAs("Stares")]
        public BlueprintFeatureReference[] m_Stares = new BlueprintFeatureReference[0];
    }
}
