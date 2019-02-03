using System;
using TMPro;
using Harmony;
using owoSaber.Misc;

namespace owoSaber.Patches
{
    [HarmonyPatch(typeof(TMP_Text))]
    [HarmonyPatch("text", MethodType.Setter)]
    internal class TMP_Text_text_set
    {
        private static bool Prefix(ref string value)
        {
            value = value.SafeOWO();
            return true;
        }
    }
}
