using BlueprintCore.Utils;
using CharacterOptionsPlus.Util;
using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.UnitLogic.Mechanics.Actions;
using Mesmerist.Utils;
using Microsoft.Build.Utilities;
using System;

namespace Mesmerist.Patches
{
    class ContextActionChangeSharedValuePatch
    {
        private static readonly Logging.Logger Logger = Logging.GetLogger(nameof(ContextActionChangeSharedValuePatch));
        
        [HarmonyPatch(typeof(ContextActionChangeSharedValue), "RunAction")]
        class ChangeSharedValue_MentalPotency_Patch
        {
            static void Postfix(ContextActionChangeSharedValue __instance)
            {
                int mentalpotency_Rank;
                bool awesomeDisplay = false;
                int awesomeDisplay_cha = 0;
                try
                {
                    var contextOwner = __instance.Context.MaybeOwner;
                    mentalpotency_Rank = contextOwner.Progression.Features.GetRank(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MentalPotency));
                }
                catch
                {
                    mentalpotency_Rank = 0;
                }
                try
                {
                    var contextOwner = __instance.Context.MaybeOwner;
                    awesomeDisplay = contextOwner.Progression.Features.HasFact(BlueprintTool.GetRef<BlueprintFeatureReference>(Guids.MythicAwesomeDisplay));
                    awesomeDisplay_cha = contextOwner.Stats.Charisma.Bonus;
                }
                catch
                {
                    awesomeDisplay= false;
                }
                int num = __instance.Context[__instance.SharedValue] + mentalpotency_Rank;
                int value;
                switch (__instance.Type)
                {
                    case SharedValueChangeType.Div2:
                        value = num / 2;
                        break;
                    case SharedValueChangeType.Add:
                        value = num + __instance.AddValue.Calculate(__instance.Context);
                        break;
                    case SharedValueChangeType.Set:
                        value = __instance.SetValue.Calculate(__instance.Context);
                        break;
                    case SharedValueChangeType.SubHD:
                        {
                            int characterLevel = __instance.Target.Unit.Descriptor.Progression.CharacterLevel;
                            if (awesomeDisplay)
                            {
                                characterLevel = characterLevel - awesomeDisplay_cha;
                                Logger.Log("Awesome Display Character Level");
                            }
                            value = num - characterLevel;
                            break;
                        }
                    case SharedValueChangeType.Div4:
                        value = num / 4;
                        break;
                    case SharedValueChangeType.Multiply:
                        value = num * __instance.MultiplyValue.Calculate(__instance.Context);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("Type");
                }
                __instance.Context[__instance.SharedValue] = value;

            }
        }
    }
}