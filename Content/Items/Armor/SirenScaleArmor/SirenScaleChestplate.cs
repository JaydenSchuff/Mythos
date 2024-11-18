using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Mythos.Content.Items.Armor.SirenScaleArmor
{
    [AutoloadEquip(EquipType.Body)]
    internal class SirenScaleChestplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(silver: 50);
            Item.rare = ItemRarityID.Orange;
            Item.defense = 10;
        }

        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 5; // +5% crit chance
            player.GetDamage(DamageClass.Ranged) += 0.05f; // +5% ranged damage

            // Grant 20% chance to not consume ammo
            player.GetModPlayer<SirenScalePlayer>().ammoConserveChestplate = true;
        }
    }

    public class SirenScalePlayer : ModPlayer
    {
        public bool ammoConserveChestplate;

        public override void OnConsumeAmmo(Item weapon, Item ammo)
        {
            // If the chestplate effect is active, 20% chance to not consume ammo
            if (ammoConserveChestplate && Main.rand.NextFloat() < 0.2f)
            {
                ammo.stack++;
            }
        }
    }
}
