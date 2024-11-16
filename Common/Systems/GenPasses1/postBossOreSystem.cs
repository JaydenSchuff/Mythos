using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Mythos.Common.Systems
{
    public class PostBossOreSystem : ModSystem
    {
        private bool sylvaSpawned = false;

        public override void OnWorldLoad()
        {
            sylvaSpawned = false; // Reset the flag when a new world is loaded
        }

        public override void OnWorldUnload()
        {
            sylvaSpawned = false; // Clean up when unloading the world
        }

        public override void SaveWorldData(TagCompound tag)
        {
            // Save the spawn state
            tag["sylvaSpawned"] = sylvaSpawned;
        }

        public override void LoadWorldData(TagCompound tag)
        {
            // Load the spawn state
            sylvaSpawned = tag.GetBool("sylvaSpawned");
        }

        public override void PostUpdateWorld()
        {
            if (!sylvaSpawned && NPC.downedBoss1)
            {
                sylvaSpawned = true;

                if (Main.netMode != NetmodeID.Server)
                {
                    Main.NewText("Sylva Ore has begun to spawn in the underground!", 50, 255, 130);
                }

                SpawnSylvaOre();
            }
        }

        private void SpawnSylvaOre()
        {
            int maxClusters = WorldGen.genRand.Next(300, 500);
            int numSpawned = 0;
            int attempts = 0;

            while (numSpawned < maxClusters)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next((int)Main.worldSurface + 50, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);

                if (tile.TileType == TileID.Stone || tile.TileType == TileID.Dirt)
                {
                    int clusterSize = WorldGen.genRand.Next(8, 20);
                    WorldGen.TileRunner(x, y, clusterSize, WorldGen.genRand.Next(4, 10), ModContent.TileType<Content.Tiles.SylvaOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts >= 100000) break; // Prevent infinite loop
            }
        }
    }
}
