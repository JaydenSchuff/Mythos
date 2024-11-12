using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mythos.Content.Items.Placeables;

namespace Mythos.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]

    internal class BrightSteelChestplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 10;
            player.GetCritChance(DamageClass.Generic) += 5;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BrightSteelBar>(), 16);
            recipe.AddIngredient(ItemID.FallenStar, 12);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
    }
}