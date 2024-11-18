using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Projectiles.Weapons;

namespace Mythos.Content.Items.Weapons.Bows
{
    internal class BrightSteelBow : ModItem
    {
        public override void SetDefaults()
        {
           Item.width = 18;
           Item.height = 18;
           Item.scale = 0.5f;

           Item.useTime = 32;
           Item.useAnimation = 32;

           Item.useStyle = ItemUseStyleID.Shoot;

           Item.autoReuse = true;

           Item.UseSound = SoundID.Item5;

           Item.DamageType = DamageClass.Ranged;
           Item.damage = 17;
           Item.knockBack = 3f;
           Item.noMelee = true;

           Item.shoot = ModContent.ProjectileType<BrightSteelArrowProjectile>();
           Item.shootSpeed = 8f;

           Item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-15f, 2f);
        }
    }
}