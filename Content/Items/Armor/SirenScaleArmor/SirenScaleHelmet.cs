using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mythos.Content.Items.Placeables;
using Terraria.Map;
using Terraria.Localization;

namespace Mythos.Content.Items.Armor.SirenScaleArmor
{
    [AutoloadEquip(EquipType.Head)]

    internal class SirenScaleHelmet : ModItem
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
            Item.rare = ItemRarityID.Orange;

            Item.defense = 6;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.GetCritChance(DamageClass.Generic) += 5;
            player.GetDamage(DamageClass.Ranged) += .05f;
        }

        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            bool bodyMatch = body.type == ModContent.ItemType<SirenScaleChestplate>();
            bool legsMatch = legs.type == ModContent.ItemType<SirenScaleGreaves>();
            return bodyMatch && legsMatch;
        }

        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = Language.GetTextValue("Mods.Mythos.ItemSetBonus.SirenScaleSet");
            if (player.wet)
                {
                    player.AddBuff(BuffID.Gills, 2);
                    player.AddBuff(BuffID.Flipper, 2);
                    player.GetDamage(DamageClass.Ranged) += .15f;
                    player.maxRunSpeed += 0.15f;
                }
        }
    }
}