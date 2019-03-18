using System;
using System.Linq;
using Harmony;

namespace owoSaber.Patches
{
    [HarmonyPatch(typeof(Console))]
    [HarmonyPatch("WriteLine")]
    [HarmonyPatch(new Type[] { typeof(string) })]
    internal class Console_WriteLine
    {
        public static bool Prefix(ref string value)
        {
            value = Replacement.ReplaceText(value);
            return true;
        }
    }

    [HarmonyPatch(typeof(Console))]
    [HarmonyPatch("WriteLine")]
    [HarmonyPatch(new Type[] { typeof(string), typeof(object) })]
    internal class Console_WriteLineFormat1
    {
        public static bool Prefix(ref object arg0)
        {
            arg0 = Replacement.ReplaceText(arg0.ToString());
            return true;
        }
    }

    [HarmonyPatch(typeof(Console))]
    [HarmonyPatch("WriteLine")]
    [HarmonyPatch(new Type[] { typeof(string), typeof(object), typeof(object) })]
    internal class Console_WriteLineFormat2
    {
        public static bool Prefix(ref object arg0, ref object arg1)
        {
            arg0 = Replacement.ReplaceText(arg0.ToString());
            arg1 = Replacement.ReplaceText(arg1.ToString());

            return true;
        }
    }

    [HarmonyPatch(typeof(Console))]
    [HarmonyPatch("WriteLine")]
    [HarmonyPatch(new Type[] { typeof(string), typeof(object[]) })]
    internal class Console_WriteLineFormatMany
    {
        public static bool Prefix(ref object[] arg)
        {
            arg = arg
                .Select(x => Replacement.ReplaceText(x.ToString()))
                .ToArray();

            return true;
        }
    }
}
