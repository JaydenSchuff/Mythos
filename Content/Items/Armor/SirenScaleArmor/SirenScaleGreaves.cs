using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Mythos.Content.Items.Placeables;

namespace Mythos.Content.Items.Armor.SirenScaleArmor
{
    [AutoloadEquip(EquipType.Legs)]

    internal class SirenScaleGreaves : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;

            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Orange;

            Item.defense = 8;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 4;
            player.GetDamage(DamageClass.Ranged) += .05f;
            player.moveSpeed += .10f; 
        }
    }
}