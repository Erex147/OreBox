using System.Reflection;
using NeoModLoader.api;
using NeoModLoader.api.features;
using ReflectionUtility;

namespace OreBox.Content;

internal static class OreBoxGodPowers
{
    public static void Init()
    {
        AddDrops();
        AddPowers();
        Cache();
    }

    private static void AddDrops()
    {
        DropAsset metal_drop = new DropAsset
        {
            id = "spawn_metal_spawner",
            path_texture = "drops/drop_metal",
            default_scale = 0.2f,
            random_frame = true,
            random_flip = true,
            type = DropType.DropBuilding,
            building_asset = "metal_spawner",
            action_landed = DropsLibrary.action_spawn_building
        };
        AssetManager.drops.add(metal_drop);

        DropAsset gold_drop = AssetManager.drops.clone("spawn_gold_spawner", metal_drop.id);
        gold_drop.building_asset = "gold_spawner";
        gold_drop.path_texture = "drops/drop_gold";

        DropAsset stone_drop = AssetManager.drops.clone("spawn_stone_spawner", metal_drop.id);
        stone_drop.building_asset = "stone_spawner";
        stone_drop.path_texture = "drops/drop_stone";

        DropAsset silver_drop = AssetManager.drops.clone("spawn_silver_spawner", metal_drop.id);
        silver_drop.building_asset = "silver_spawner";
        silver_drop.path_texture = "drops/drop_stone";

        DropAsset mythril_drop = AssetManager.drops.clone("spawn_mythril_spawner", metal_drop.id);
        mythril_drop.building_asset = "mythril_spawner";
        mythril_drop.path_texture = "drops/drop_stone";

        DropAsset adamantine_drop = AssetManager.drops.clone("spawn_adamantine_spawner", metal_drop.id);
        adamantine_drop.building_asset = "adamantine_spawner";
        adamantine_drop.path_texture = "drops/drop_stone";
    }

    private static void AddPowers()
    {
        GodPower metal_spawner = AssetManager.powers.clone("metal_spawner", "$template_drop_building$");
        metal_spawner.name = "Metal Spawner";
        metal_spawner.rank = PowerRank.Rank0_free;
        metal_spawner.drop_id = "spawn_metal_spawner";
        metal_spawner.falling_chance = 0f;
        metal_spawner.force_brush = "circ_0";
        metal_spawner.click_power_action = StuffDrop;
        metal_spawner.click_power_brush_action = new PowerAction((pTile, pPower) =>
        {
            return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPowerForDropsFull", pTile, pPower);
        });

        GodPower gold_spawner = AssetManager.powers.clone("gold_spawner", metal_spawner.id);
        gold_spawner.name = "Gold Spawner";
        gold_spawner.drop_id = "spawn_gold_spawner";

        GodPower stone_spawner = AssetManager.powers.clone("stone_spawner", metal_spawner.id);
        stone_spawner.name = "Stone Spawner";
        stone_spawner.drop_id = "spawn_stone_spawner";

        GodPower silver_spawner = AssetManager.powers.clone("silver_spawner", metal_spawner.id);
        silver_spawner.name = "Silver Spawner";
        silver_spawner.drop_id = "spawn_silver_spawner";

        GodPower mythril_spawner = AssetManager.powers.clone("mythril_spawner", metal_spawner.id);
        mythril_spawner.name = "Mythril Spawner";
        mythril_spawner.drop_id = "spawn_mythril_spawner";

        GodPower adamantine_spawner = AssetManager.powers.clone("adamantine_spawner", metal_spawner.id);
        adamantine_spawner.name = "Adamantine Spawner";
        adamantine_spawner.drop_id = "spawn_adamantine_spawner";
    }

    private static void Cache()
    {
        FieldInfo dropField = typeof(GodPower).GetField("cached_drop_asset", BindingFlags.NonPublic | BindingFlags.Instance);
        if (dropField != null)
        {
            dropField.SetValue(AssetManager.powers.get("metal_spawner"), AssetManager.drops.get("spawn_metal_spawner"));
            dropField.SetValue(AssetManager.powers.get("gold_spawner"), AssetManager.drops.get("spawn_gold_spawner"));
            dropField.SetValue(AssetManager.powers.get("stone_spawner"), AssetManager.drops.get("spawn_stone_spawner"));
            dropField.SetValue(AssetManager.powers.get("silver_spawner"), AssetManager.drops.get("spawn_silver_spawner"));
            dropField.SetValue(AssetManager.powers.get("mythril_spawner"), AssetManager.drops.get("spawn_mythril_spawner"));
            dropField.SetValue(AssetManager.powers.get("adamantine_spawner"), AssetManager.drops.get("spawn_adamantine_spawner"));
        }
    }

    private static bool StuffDrop(WorldTile pTile, GodPower pPower)
    {
        AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
        return true;
    }
}