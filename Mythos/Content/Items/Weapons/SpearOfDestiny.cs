using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mythos.Content.Projectiles.Weapons;

namespace Mythos.Content.Items.Weapons
{ 
    public class SpearOfDestiny : ModItem
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
		public override void SetDefaults()
		{
			Item.width = 70;
            Item.height = 60;
			Item.scale = 1.6f;

            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.useStyle = ItemUseStyleID.Rapier;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 160;
            Item.knockBack = 5f;

            Item.value = Item.buyPrice(gold: 5);
            Item.rare = ItemRarityID.Blue;

			Item.noUseGraphic = true;
			Item.noMelee = true;

			Item.shootSpeed = 2.1f;
			Item.shoot = ModContent.ProjectileType<SpearOfDestinyProjectile>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 10);
			recipe.AddIngredient(ItemID.FallenStar, 5);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}
