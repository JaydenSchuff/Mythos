using Mythos.Content.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Tools
{ 
	internal class BrightSteelPickaxe : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
		public override void SetDefaults()
		{
			Item.width = 40;
            Item.height = 40;

            Item.useTime = 10;
            Item.useAnimation = 12;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 8;
            Item.knockBack = 3f;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.pick = 60;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			 recipe.AddIngredient(ModContent.ItemType<BrightSteelBar>(), 12);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 4);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
