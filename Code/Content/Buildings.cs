using System.Net.Mime;

namespace OreBox.Content;

internal static class OreBoxBuildings
{
    public static void Init()
    {
        AddSpawners();
        PreloadHelpers.preloadBuildingSprites();
    }

    private static void AddSpawners()
    {
        BuildingAsset metal_spawner = AssetManager.buildings.clone("metal_spawner", "$building$");
        metal_spawner.building_type = BuildingType.Building_Nature;
        metal_spawner.type = "orebox_spawner";
        metal_spawner.draw_light_area = true;
        metal_spawner.ignored_by_cities = false;
        metal_spawner.draw_light_size = 1f;
        metal_spawner.base_stats["health"] = 50000f;
        metal_spawner.fundament = new BuildingFundament(1, 1, 1, 0);
        metal_spawner.group = "nature";
        metal_spawner.kingdom = "nature";
        metal_spawner.can_be_placed_on_liquid = false;
        metal_spawner.ignore_buildings = true;
        metal_spawner.check_for_close_building = false;
        metal_spawner.can_be_living_house = true;
        metal_spawner.burnable = false;
        metal_spawner.setShadow(0.28f, 0.86f, 0f);
        metal_spawner.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
        metal_spawner.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
        metal_spawner.has_sprites_spawn = true;
        metal_spawner.has_sprites_main = true;
        metal_spawner.has_sprites_ruin = true;
        metal_spawner.has_sprites_special = false;
        metal_spawner.has_sprites_main_disabled = false;
        metal_spawner.sprite_path = "buildings/metal_spawner";
        metal_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        metal_spawner.spawn_drops = true;
        metal_spawner.spawn_drop_id = "metals";
        metal_spawner.has_special_animation_state = false;
        metal_spawner.spawn_drop_interval = 1f;
        metal_spawner.spawn_drop_min_height = 10f;
        metal_spawner.spawn_drop_min_radius = 1f;
        metal_spawner.spawn_drop_max_radius = 10f;
        metal_spawner.spawn_drop_max_height = 20f;
        metal_spawner.spawn_drop_start_height = 10f;
        //metal_spawner.loadBuildingSprites();

        BuildingAsset gold_spawner = AssetManager.buildings.clone("gold_spawner", metal_spawner.id);
        gold_spawner.sprite_path = "buildings/gold_spawner";
        gold_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        gold_spawner.spawn_drop_id = "gold";
        //gold_spawner.loadBuildingSprites();

        BuildingAsset stone_spawner = AssetManager.buildings.clone("stone_spawner", metal_spawner.id);
        stone_spawner.sprite_path = "buildings/stone_spawner";
        stone_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        stone_spawner.spawn_drop_id = "stone";
        //stone_spawner.loadBuildingSprites();

        BuildingAsset silver_spawner = AssetManager.buildings.clone("silver_spawner", metal_spawner.id);
        silver_spawner.sprite_path = "buildings/silver_spawner";
        silver_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        silver_spawner.spawn_drop_id = "silver";
        //silver_spawner.loadBuildingSprites();

        BuildingAsset mythril_spawner = AssetManager.buildings.clone("mythril_spawner", metal_spawner.id);
        mythril_spawner.sprite_path = "buildings/mythril_spawner";
        mythril_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        mythril_spawner.spawn_drop_id = "mythril";
        //mythril_spawner.loadBuildingSprites();

        BuildingAsset adamantine_spawner = AssetManager.buildings.clone("adamantine_spawner", metal_spawner.id);
        adamantine_spawner.sprite_path = "buildings/adamantine_spawner";
        adamantine_spawner.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
        adamantine_spawner.spawn_drop_id = "adamantine";
        //adamantine_spawner.loadBuildingSprites();
    }
}