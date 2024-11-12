using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mythos.Content.Projectiles.Weapons;
using Microsoft.Xna.Framework;

namespace Mythos.Content.Items.Weapons
{
    internal class Cornucopia : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.scale = 0.5f;

            Item.useTime = 20;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.UseSound = SoundID.Item70;
            Item.useTurn = true;

            Item.DamageType = DamageClass.Magic;
            Item.noMelee = true;
            Item.mana = 8;
            Item.damage = 27;
            Item.knockBack = 2.1f;

            Item.value = Item.buyPrice(gold: 1);

            Item.shootSpeed = 1.5f;  // Adjust shoot speed (controls how fast the projectile moves)
            Item.shoot = ModContent.ProjectileType<CornucopiaProjectile>();
        }
    }
}
