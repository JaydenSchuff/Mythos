using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Mythos.Content.Tiles;

namespace Mythos.Common.Systems.GenPasses1
{

    internal class BrightSteelOreGenPass : GenPass
    {
        public BrightSteelOreGenPass(string name, float weight) : base(name, weight) {  }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Spawning Mythos Ores";

            // Set a fixed maximum number of clusters to spawn
            int maxClusters = WorldGen.genRand.Next(400, 600);
            int numSpawned = 0;
            int attempts = 0;

            while (numSpawned < maxClusters)
            {
                // Randomly select a position within the world
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next(0, Main.maxTilesY);

                // Check if the position is in a cloud tile
                Tile tile = Framing.GetTileSafely(x, y);
                if (tile.TileType == TileID.Cloud || tile.TileType == TileID.SnowCloud)
                {
                    // Generate a single ore cluster of 10-25 blocks within the cloud tile
                    int clusterSize = WorldGen.genRand.Next(10, 25);
                    WorldGen.TileRunner(x, y, clusterSize, WorldGen.genRand.Next(4, 15), ModContent.TileType<BrightSteelOre>());
                    numSpawned++;
                }

                // Limit attempts to prevent infinite loops
                attempts++;
                if (attempts >= 100000)
                {
                    break;
                }
            }
        }
    }
}