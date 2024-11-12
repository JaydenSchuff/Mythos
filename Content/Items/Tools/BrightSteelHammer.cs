using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mythos.Content.Items.Placeables;

namespace Mythos.Content.Items.Tools
{
    internal class BrightSteelHammer : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;

            Item.useTime = 16;
            Item.useAnimation = 23;
            Item.autoReuse = true;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTurn = true;

            Item.DamageType = DamageClass.Melee;
            Item.damage = 12;
            Item.knockBack = 3f;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.hammer = 60;
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