using System;
using System.Collections.Generic;
using NCMS.Utils;
using NeoModLoader.api.attributes;
using NeoModLoader.General;
using NeoModLoader.General.UI.Tab;
using OreBox.UI.Windows;

namespace OreBox.UI;

internal static class OreBoxUI
{
    public static PowersTab tab;

    public static void Init()
    {
        tab = TabManager.CreateTab(
            "orebox_tab",
            "orebox_tab_name",
            "orebox_tab_description",
            SpriteTextureLoader.getSprite("ui/icons/orebox_tab_icon")
        );

        tab.SetLayout(new List<string>()
        {
            "spawners"
        });

        CreateWindows();
        CreateButtons();
        tab.UpdateLayout();
    }

    private static void CreateWindows()
    {
        OreBoxAutoLayoutWindow.CreateWindow("orebox_auto_layout_window", "orebox_auto_layout_window_title");
    }

    private static void CreateButtons()
    {
        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "metal_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/metal_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "gold_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/gold_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "stone_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/stone_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "silver_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/silver_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "mythril_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/mythril_spawner")
        ));

        tab.AddPowerButton("spawners", PowerButtonCreator.CreateGodPowerButton(
            "adamantine_spawner",
            SpriteTextureLoader.getSprite("ui/icons/buttons/adamantine_spawner")
        ));
    }
}