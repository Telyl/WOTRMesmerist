using Kingmaker.Blueprints;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.UnitLogic;
using Mesmerist.NewUnitParts;
using TabletopTweaks.Core.NewUnitParts;

namespace Mesmerist.NewComponents.AbilitySpecific
{
    [AllowMultipleComponents]
    [TypeId("73e2dbae7f4d4fe4864c555dc6a06067")]
    public class AddPainfulStareComponent : UnitFactComponentDelegate
    {
        public override void OnTurnOn()
        {
            var UnitPartPainfulStare = Owner.Ensure<UnitPartPainfulStare>();
            UnitPartPainfulStare.SetClass(m_Class);
            UnitPartPainfulStare.SetHypnoticStare(m_HypnoticStare);
            UnitPartPainfulStare.SetIntensePain(m_IntensePain);
            UnitPartPainfulStare.SetManifoldStare(m_ManifoldStare);
            UnitPartPainfulStare.SetPainfulStare(m_PainfulStare);
            UnitPartPainfulStare.SetPiercingStrike(m_PiercingStrike);
        }
        public override void OnTurnOff()
        {
            var UnitPartPainfulStare = Owner.Get<UnitPartAccursedHexTTT>();
            if (UnitPartPainfulStare == null) { return; }
            UnitPartPainfulStare.Remove();
        }

        public BlueprintCharacterClassReference m_Class;
        public BlueprintBuffReference m_HypnoticStare;
        public BlueprintFeatureReference m_IntensePain;
        public BlueprintFeatureReference m_ManifoldStare;
        public BlueprintFeatureReference m_PainfulStare;
        public BlueprintFeatureReference m_PiercingStrike;
    }
}