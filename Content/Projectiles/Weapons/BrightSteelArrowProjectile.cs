using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;
using Microsoft.Xna.Framework;
using System;

namespace Mythos.Content.Projectiles.Weapons
{ 
	public class BrightSteelArrowProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;

            Projectile.aiStyle = 1;

            Projectile.friendly = true;
            Projectile.hostile = false;

            Projectile.penetrate = 1;

            Projectile.timeLeft = 600;

            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;

            Projectile.extraUpdates = 1;

            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if(Projectile.penetrate <= 0)
            {
                Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
                Projectile.Kill();
                return false;
            }

            return false;
        }
    }
}