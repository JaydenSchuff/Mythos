using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Placeables
{ 
	public class BrightSteelBar : ModItem
	{
        public override void SetStaticDefaults()
        {
            ItemID.Sets.SortingPriorityMaterials[Type] = 59;
        }
        // The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
        public override void SetDefaults()
		{
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 999;
            Item.consumable = true;
            Item.value = Item.buyPrice(silver: 4);

            Item.useStyle = ItemUseStyleID.Swing;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useTurn = true;
            Item.autoReuse = true;

            Item.createTile = ModContent.TileType<Tiles.BrightSteelBar>();
            Item.placeStyle = 0;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient<BrightSteelOre>(4);
			recipe.AddTile(TileID.Furnaces);
			recipe.Register();
		}
	}
}
