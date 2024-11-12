using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mythos.Content.Projectiles.Weapons;

namespace Mythos.Content.Items.Weapons.Ammo
{
    internal class BrightSteelArrow : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 8;

            Item.damage = 10;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 1.25f;

            Item.maxStack = 999;
            Item.consumable = true;

            Item.ammo = AmmoID.Arrow;
            Item.shoot = ModContent.ProjectileType<BrightSteelArrowProjectile>();
        }
    }
}