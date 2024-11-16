using Mythos.Content.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Weapons.Swords
{ 
	public class BrightSteelSword : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
		public override void SetDefaults()
		{
			Item.width = 18;
            Item.height = 18;
			Item.scale = 1.5f;

            Item.useTime = 18;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;
			Item.autoReuse = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 22;
            Item.knockBack = 6f;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BrightSteelBar>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
