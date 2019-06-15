using System;
using System.Reflection;
using IPA;
using Harmony;
using owoSaber.Misc;
using Logger = owoSaber.Misc.Logger;
using UnityEngine.SceneManagement;

namespace owoSaber
{
    public class Plugin : IBeatSaberPlugin
    {
        public string Name => "owoSaber";
        public string Version => "0.2.0";

        public void Init(IPA.Logging.Logger logger)
        {
            Logger.logger = logger;
        }

        public void OnApplicationStart()
        {
            try
            {
                HarmonyInstance harmony = HarmonyInstance.Create("com.jackbaron.beatsaber.owoSaber");
                harmony.PatchAll(Assembly.GetExecutingAssembly());

                Logger.Log("Patched successfully!");
            }
            catch (Exception e)
            {
                Logger.Log(
                    "This plugin requires Harmony. Make sure you installed the plugin " +
                    "properly, as the Harmony DLL should have been installed with it.",
                    Logger.LogLevel.Warning);

                Console.WriteLine(e);
            }

            string title = WindowTitle.Get();
            string replaced = Replacement.ReplaceText(title);
            WindowTitle.Set(replaced);
        }

        public void OnApplicationQuit() { }

        public void OnLevelWasInitialized(int level) { }

        public void OnLevelWasLoaded(int level) { }

        public void OnUpdate() { }

        public void OnFixedUpdate() { }

        public void OnSceneLoaded(Scene scene, LoadSceneMode sceneMode) { }

        public void OnSceneUnloaded(Scene scene) { }

        public void OnActiveSceneChanged(Scene prevScene, Scene nextScene) { }
    }
}
