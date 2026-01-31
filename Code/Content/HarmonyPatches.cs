using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace OreBox.Content;

internal static class OreBoxPatches
{
    internal static Harmony harmony;
    
    public static void Init()
    {
        harmony = new Harmony("com.Erex147.WarBox");
        Assembly assembly = Assembly.GetExecutingAssembly();

        try
        {
            harmony.PatchAll(assembly);
        }
        catch (Exception e)
        {
            OreBox.LogError(e.ToString());
        }
    }
}

[HarmonyPatch(typeof(PowerLibrary))]
internal static class PowerLibrary_Patch
{
    [HarmonyPatch("drawTemperaturePlus")]
    [HarmonyPrefix]
    static bool Plus(ref bool __result, PowerLibrary __instance, WorldTile pTile, string pPower)
    {
        if (pTile.isTemporaryFrozen() && Randy.randomBool())
        {
            pTile.unfreeze();
        }
        WorldBehaviourUnitTemperatures.checkTile(pTile, 5);
        if (pTile.Type.lava)
        {
            LavaHelper.heatUpLava(pTile);
        }
        if (pTile.hasBuilding() && pTile.building.asset.spawn_drops && pTile.building.asset.type != "orebox_spawner")
        {
            pTile.building.data.removeFlag("stop_spawn_drops");
        }
        __result = true;
        return false;
    }

    [HarmonyPatch("drawTemperatureMinus")]
    [HarmonyPrefix]
    static bool Plus(ref bool __result, WorldTile pTile, string pPower)
    {
        if (pTile.Type.lava)
        {
            LavaHelper.coolDownLava(pTile);
        }
        if (pTile.isOnFire())
        {
            pTile.stopFire();
        }
        if (pTile.canBeFrozen() && Randy.randomBool())
        {
            if (pTile.health > 0)
            {
                pTile.health--;
            }
            else
            {
                pTile.freeze();
            }
        }
        WorldBehaviourUnitTemperatures.checkTile(pTile, -5);
        if (pTile.hasBuilding())
        {
            ActionLibrary.addFrozenEffectOnTarget(null, pTile.building);
        }
        if (pTile.hasBuilding() && pTile.building.asset.spawn_drops && pTile.building.asset.type != "orebox_spawner")
        {
            pTile.building.data.addFlag("stop_spawn_drops");
        }
        __result = true;
        return false;
    }
}


// [HarmonyPatch(typeof(Building), nameof(Building.calculateMainSprite))]
// public class Building_calculateMainSprite
// {
//     static bool Prefix(ref Sprite __result, Building __instance)
//     {
//         bool flag = true;
//         Sprite[] array = null;
//         bool flag2 = __instance.isRuin();
//         if (flag2)
//         {
//             flag = false;
//         }
//         if (__instance.isUnderConstruction())
//         {
//             __instance.last_main_sprite = __instance.asset.building_sprites.construction;
//             __result = __instance.last_main_sprite;
//         }
//         if (__instance.asset.has_special_animation_state)
//         {
//             array = ((!__instance.hasResourcesToCollect()) ? __instance.animData.special : __instance.animData.main);
//         }
//         else if (flag2 && __instance.asset.has_ruins_graphics)
//         {
//             flag = false;
//             array = __instance.animData.ruins;
//         }
//         else if (__instance.asset.spawn_drops && __instance.data.hasFlag("stop_spawn_drops") && __instance.asset.type != "orebox_spawner")
//         {
//             array = __instance.animData.main_disabled;
//         }
//         else if (__instance.asset.can_be_abandoned && __instance.isAbandoned())
//         {
//             Sprite[] main_disabled = __instance.animData.main_disabled;
//             array = ((main_disabled == null || main_disabled.Length == 0) ? __instance.animData.main : __instance.animData.main_disabled);
//             flag = false;
//         }
//         else
//         {
//             array = __instance.animData.main;
//             if (__instance.asset.get_override_sprites_main != null)
//             {
//                 Sprite[] array2 = __instance.asset.get_override_sprites_main(__instance);
//                 if (array2 != null)
//                 {
//                     array = array2;
//                 }
//             }
//         }
//         Sprite sprite = null;
//         if (__instance.check_spawn_animation)
//         {
//             __result = __instance.getSpawnFrameSprite();
//         }
//         if (!flag || array.Length == 1)
//         {
//             __result = array[0];
//         }
//         __result = AnimationHelper.getSpriteFromList(__instance.GetHashCode(), array, __instance.asset.animation_speed);
//         return false;
//     }
// }