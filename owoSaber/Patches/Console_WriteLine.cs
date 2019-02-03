using System;
using System.Linq;
using Harmony;
using owoSaber.Misc;

namespace owoSaber.Patches
{
    [HarmonyPatch(typeof(Console))]
    [HarmonyPatch("WriteLine")]
    [HarmonyPatch(new Type[] { typeof(string) })]
    internal class Console_WriteLine
    {
        public static bool Prefix(ref string value)
        {
            value = value.OwO();
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
            arg0 = arg0.ToString().OwO();
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
            arg0 = arg0.ToString().OwO();
            arg1 = arg1.ToString().OwO();

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
                .Select(x => x.ToString().OwO())
                .ToArray();

            return true;
        }
    }
}
