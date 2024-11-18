using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Projectiles.Weapons;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace Mythos.Content.Items.Weapons.Bows
{
    internal class RiptideBow : ModItem
    {
        public override void SetDefaults()
        {
           Item.width = 46;
           Item.height = 90;
           Item.scale = 0.6f;

           Item.useTime = 25;
           Item.useAnimation = 25;

           Item.useStyle = ItemUseStyleID.Shoot;

           Item.autoReuse = true;

           Item.UseSound = SoundID.Item5;

           Item.DamageType = DamageClass.Ranged;
           Item.damage = 25;
           Item.knockBack = 8f;
           Item.noMelee = true;

           Item.shoot = ProjectileID.WoodenArrowFriendly;
           Item.shootSpeed = 15f;
        }
    

public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
{
    // Number of projectiles to shoot
    int numberProjectiles = 2;
    float pi = 3.14159265f;

    // Normalize the initial velocity and adjust the spawn distance
    Vector2 initialVelocity = velocity;
    initialVelocity.Normalize();
    initialVelocity *= 40f;

    // Check if the projectile can hit directly in front of the player
    bool canHit = Collision.CanHit(position, 0, 0, position + initialVelocity, 0, 0);

    // Loop to create multiple projectiles
    for (int i = 0; i < numberProjectiles; i++)
    {
        // Calculate the rotation offset for each projectile
        float offset = (i - (numberProjectiles - 1f) / 2f);
        Vector2 rotatedOffset = initialVelocity.RotatedBy(pi * offset / 10);

        // Adjust position if a collision would block the original spawn position
        if (!canHit)
        {
            rotatedOffset -= initialVelocity;
        }

        // Calculate the new position for each projectile
        Vector2 newPosition = position + rotatedOffset;

        // Create the projectile with the adjusted position and original velocity
        Projectile.NewProjectile(
            source,               // Source of the projectile
            newPosition,          // Adjusted position
            velocity,             // Original velocity
            type,                 // Projectile type
            damage,               // Damage
            knockback,            // Knockback
            player.whoAmI         // Owner
        );
    }

    // Return false to prevent the default projectile from being fired
    return false;
}




        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-5f, 2f);
        }
    }
}