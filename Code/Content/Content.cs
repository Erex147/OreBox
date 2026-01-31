using System;
using NeoModLoader.api.attributes;

namespace OreBox.Content;

internal static class OreBoxContent
{
    public static void Init()
    {
        OreBoxBuildings.Init();
        OreBoxGodPowers.Init();
        OreBoxPatches.Init();
    }
}