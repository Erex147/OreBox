using System;
using System.IO;
using OreBox.Content;
using OreBox.UI;
using NeoModLoader.api;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using UnityEngine;
using System.Reflection;
using System.Collections.Generic;

namespace OreBox;

public class OreBox : BasicMod<OreBox>, IReloadable
{
    public static Transform prefab_library;

    [Hotfixable]
    public void Reload()
    {

    }

    public void OnUnload()
    {

    }

    protected override void OnModLoad()
    {
        prefab_library = new GameObject("PrefabLibrary").transform;
        prefab_library.SetParent(transform);
        
        if (Environment.UserName == "sourojeetshyam")
        {
            Config.isEditor = true;
        }

        OreBoxContent.Init();
        OreBoxUI.Init();
    }

    public static void Called()
    {
        LogInfo("Hello World From Another!");
    }
}