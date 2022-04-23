using System.Linq;
using HarmonyLib;

namespace ChooseHellgateLevels
{
    [HarmonyPatch(typeof(MapManager))]
    public class MapManagerPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GetRandomHellLocation")]
        static GameLocation GetRandomHellLocationPostfix(GameLocation __result, MapManager __instance)
        {
            if (ModLoader.Config != null)
            {
                return (from c in __instance.AllLocations
                    where (c.Attributes & GameLocationAttributes.HellLevel) > GameLocationAttributes.None 
                          && !ModLoader.Config.LevelsToExclude.Contains(c.GameLocationName)
                    select c into p
                    orderby UnityEngine.Random.value
                    select p).FirstOrDefault();
            }

            return __result;
        }
    }
}