using System;
using owoSaber.Misc;

namespace owoSaber
{
    internal static class Replacement
    {
        internal static string ReplaceText(string text)
        {
            return text.SafeOWO();
        }
    }
}
