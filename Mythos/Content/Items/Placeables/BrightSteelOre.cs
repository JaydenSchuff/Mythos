using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Placeables
{ 
	public class BrightSteelOre : ModItem
	{
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Type] = 58;
        }
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
        public override void SetDefaults()
		{
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(silver: 1);

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<Tiles.BrightSteelOre>();
        }
	}
}
