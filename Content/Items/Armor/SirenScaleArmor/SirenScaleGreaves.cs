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
            Item.rare = ItemRarityID.Blue;

            Item.defense = 5;
        }

        public override void UpdateEquip(Player player)
        {
            player.statLifeMax2 += 5;
            player.GetCritChance(DamageClass.Generic) += 3;
        }
    }
}