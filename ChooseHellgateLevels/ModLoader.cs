using System;
using System.IO;
using System.Linq;
using HarmonyLib;
using Newtonsoft.Json;

namespace ChooseHellgateLevels
{
    public class ModLoader : IModLoader
    {
        private static string ConfigPath = Path.Combine(LoadingManager.PersistantDataPath, "choose-hellgate-levels.config.json");
        public static ModConfig Config;
        
        public void OnCreated()
        {
            if (File.Exists(ConfigPath))
            {
                Config = JsonConvert.DeserializeObject<ModConfig>(File.ReadAllText(ConfigPath));
            }
            else
            {
                Config = this.CreateAndSaveNewConfig();
            }
            
            var harmony = new Harmony("com.apxeolog.choose-hellgate-levels");
            harmony.PatchAll();
        }

        private ModConfig CreateAndSaveNewConfig()
        {
            var config = new ModConfig
            {
                LevelsToExclude = Array.Empty<string>(),
                AllHellgateLevels = MapManager.instance.AllLocations.Where(
                        location => (location.Attributes & GameLocationAttributes.HellLevel) >
                                    GameLocationAttributes.None)
                    .Select(location => location.GameLocationName).ToArray()
            };
            File.WriteAllText(ConfigPath, JsonConvert.SerializeObject(config, Formatting.Indented));
            return config;
        }

        public void OnReleased()
        {
        }

        public void OnGameLoaded(LoadMode mode)
        {
        }

        public void OnGameUnloaded()
        {
        }
    }
}