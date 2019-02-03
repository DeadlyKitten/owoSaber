using System;
using System.Reflection;
using IllusionPlugin;
using Harmony;
using Logger = owoSaber.Misc.Logger;

namespace owoSaber
{
    public class Plugin : IPlugin
    {
        public string Name => "owoSaber";
        public string Version => "0.1.0";

        public void OnApplicationStart()
        {
            try
            {
                HarmonyInstance harmony = HarmonyInstance.Create("com.jackbaron.beatsaber.owoSaber");
                harmony.PatchAll(Assembly.GetExecutingAssembly());

                Logger.Debug("Patched successfully!");
            }
            catch (Exception e)
            {
                Logger.Log(
                    "This plugin requires Harmony. Make sure you installed the plugin " +
                    "properly, as the Harmony DLL should have been installed with it."
                );

                Console.WriteLine(e);
            }
        }

        public void OnApplicationQuit() { }

        public void OnLevelWasInitialized(int level) { }

        public void OnLevelWasLoaded(int level) { }

        public void OnUpdate() { }

        public void OnFixedUpdate() { }
    }
}
