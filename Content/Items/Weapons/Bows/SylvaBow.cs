using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Projectiles.Weapons;

namespace Mythos.Content.Items.Weapons.Bows
{ 
    internal class SylvaBow : ModItem
    {
        public override void SetDefaults()
        {
           Item.width = 20;
           Item.height = 40;
           Item.scale = 1.15f;

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

        public override void PostUpdate()
        {
            // Apply the scale to the item when dropped in the world
            Item.scale = 1.2f; // Match your desired scale
        }
    }
}