using Terraria;
using Terraria.IO;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Mythos.Content.Tiles;

namespace Mythos.Common.Systems.GenPasses1
{
    internal class OreGenPass : GenPass
    {
        private readonly string oreType;

        public OreGenPass(string name, float weight, string oreType) : base(name, weight)
        {
            this.oreType = oreType;
        }

        protected override void ApplyPass(GenerationProgress progress, GameConfiguration configuration)
        {
            if (oreType == "BrightSteel")
            {
                GenerateBrightSteelOre(progress);
            }
        }

        private void GenerateBrightSteelOre(GenerationProgress progress)
        {
            progress.Message = "Spawning Bright Steel Ore";

            int maxClusters = WorldGen.genRand.Next(400, 600);
            int numSpawned = 0;
            int attempts = 0;

            while (numSpawned < maxClusters)
            {
                int x = WorldGen.genRand.Next(0, Main.maxTilesX);
                int y = WorldGen.genRand.Next(0, Main.maxTilesY);
                Tile tile = Framing.GetTileSafely(x, y);

                if (tile.TileType == TileID.Cloud || tile.TileType == TileID.SnowCloud)
                {
                    int clusterSize = WorldGen.genRand.Next(10, 25);
                    WorldGen.TileRunner(x, y, clusterSize, WorldGen.genRand.Next(4, 15), ModContent.TileType<BrightSteelOre>());
                    numSpawned++;
                }

                attempts++;
                if (attempts >= 100000) break;
            }
        }
    }
}
