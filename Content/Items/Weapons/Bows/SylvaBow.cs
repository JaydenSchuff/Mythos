using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Projectiles.Weapons;

namespace Mythos.Content.Items.Weapons.Bows
{ 
    public class SylvaBow : ModItem
    {
        public override void SetDefaults()
        {
           Item.width = 40;
           Item.height = 80;
           Item.scale = 0.5f;

           Item.useTime = 32;
           Item.useAnimation = 32;

           Item.useStyle = ItemUseStyleID.Shoot;

           Item.autoReuse = true;

           Item.UseSound = SoundID.Item5;

           Item.DamageType = DamageClass.Ranged;
           Item.damage = 75;
           Item.knockBack = 3f;
           Item.noMelee = true;

           Item.shoot = ProjectileID.WoodenArrowFriendly;
           Item.shootSpeed = 12f;

           Item.useAmmo = AmmoID.Arrow;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }
    }
}