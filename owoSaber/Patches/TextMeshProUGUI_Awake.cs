using System;
using TMPro;
using Harmony;
using owoSaber.Misc;

namespace owoSaber.Patches
{
    [HarmonyPatch(typeof(TextMeshProUGUI))]
    [HarmonyPatch("Awake")]
    internal class TextMeshProUGUI_Awake
    {
        public static void Postfix(TextMeshProUGUI __instance)
        {
            __instance.text = __instance.text.SafeOWO();
        }
    }
}
