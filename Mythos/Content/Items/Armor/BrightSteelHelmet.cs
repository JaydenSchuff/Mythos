using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mythos.Content.Items.Placeables;
using Terraria.Map;
using Terraria.Localization;

namespace Mythos.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]

    internal class BrightSteelHelmet : ModItem
    {
        public override void SetStaticDefaults()
        {
            //ArmorIDs.Head.Sets.DrawHead[Item.headSlot] = false;
        }

        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;

            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.GetCritChance(DamageClass.Generic) += 4;
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<BrightSteelBar>(), 8);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            bool bodyMatch = body.type == ModContent.ItemType<BrightSteelChestplate>();
            bool legsMatch = legs.type == ModContent.ItemType<BrightSteelGreaves>();
            return bodyMatch && legsMatch;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.Mythos.ItemSetBonus.BrightSteelSet");
            if (player.HeldItem.DamageType == DamageClass.Melee)
                {
                    player.AddBuff(BuffID.WeaponImbueIchor, 2);
                }
        }
    }
}