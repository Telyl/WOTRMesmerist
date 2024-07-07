using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker.UnitLogic.ActivatableAbilities;
using Kingmaker.UnitLogic.Parts;
using System;

namespace Mesmerist.MechanicsChanges
{
    internal class ExpandedActivatableAbilityGroup
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ExpandedActivatableAbilityGroup));

        internal const ActivatableAbilityGroup MesmeristTricks = (ActivatableAbilityGroup)1818;
        internal const ActivatableAbilityGroup ManifoldTricks = (ActivatableAbilityGroup)1819;
        internal const ActivatableAbilityGroup Stares = (ActivatableAbilityGroup)1820;

        [HarmonyPatch(typeof(UnitPartActivatableAbility))]
        static class UnitPartActivatableAbility_Patch
        {
            [HarmonyPatch(nameof(UnitPartActivatableAbility.GetGroupSize)), HarmonyPrefix]
            static bool GetGroupSize(ActivatableAbilityGroup group, ref int __result)
            {
                try
                {
                    if (group == MesmeristTricks)
                    {
                        Logger.Verbose(() => "Returning group size for MesmeristTricks");
                        __result = 1;
                        return false;
                    }
                    else if (group == ManifoldTricks)
                    {
                        Logger.Verbose(() => "Returning group size for ManifoldTricks");
                        __result = 1;
                        return false;
                    }
                    else if (group == Stares)
                    {
                        Logger.Verbose(() => "Returning group size for Stares");
                        __result = 1;
                        return false;
                    }
                }
                catch (Exception e)
                {
                    Logger.LogException("UnitPartActivatableAbility_Patch.GetGroupSize", e);
                }
                return true;
            }
        }
    }
}