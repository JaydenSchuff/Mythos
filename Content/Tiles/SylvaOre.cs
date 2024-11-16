using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Mythos.Content.Tiles
{ 
	public class SylvaOre : ModTile
	{
        public override void SetStaticDefaults()
        {
            TileID.Sets.Ore[Type] = true;

            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileShine[Type] = 900;
            Main.tileShine2[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileOreFinderPriority[Type] = 375;

            AddMapEntry(new Color(200,200,200), CreateMapEntryName());

            DustType = DustID.Chlorophyte;
            HitSound = SoundID.Tink;

            MineResist = 1.5f;
            MinPick = 120;
        }
	}
}
