using Mythos.Content.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Tools
{ 
	internal class BrightSteelAxe : ModItem
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
            Item.damage = 6;
            Item.knockBack = 3f;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.axe = 60;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BrightSteelBar>(), 8);
			recipe.AddRecipeGroup(RecipeGroupID.Wood, 3);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
