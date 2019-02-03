using System;

namespace owoSaber.Misc
{
    static class Logger
    {
        public static void Log(object data)
        {
            Console.WriteLine($"[owoSaber] {data}");
        }

        public static void Debug(object data)
        {
#if DEBUG
            Console.WriteLine($"[owoSaber // DEBUG] {data}");
#endif
        }
    }
}
