using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Dust;

namespace Mythos.Content.Projectiles.Weapons
{
    internal class CornucopiaProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.scale = 0.8f;

            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0; // Custom AI
        }

        public override void AI()
        {
            // Only calculate and spawn projectiles once
            if (Projectile.ai[0] == 0)
            {
                // Set velocity to current direction (keep initial launch direction)
                Vector2 targetDirection = Main.MouseWorld - Projectile.position;
                targetDirection.Normalize();
                Projectile.velocity = targetDirection * 10f; // Initial speed

                // Spawn the smaller projectiles with slight spread
                for (int i = -1; i <= 1; i++)
                {
                    if (i == 0) continue; // Skip the main projectile, only spawn smaller ones

                    float rotation = MathHelper.ToRadians(10) * i; // Spread angle
                    Vector2 newVelocity = Projectile.velocity.RotatedBy(rotation) * 0.75f;

                    // Spawn smaller projectiles
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(),
                        Projectile.Center, newVelocity,
                        ModContent.ProjectileType<CornucopiaSmallProjectile>(),
                        Projectile.damage, Projectile.knockBack,
                        Projectile.owner);
                }

                // Mark as initialized
                Projectile.ai[0] = 1;
            }

            // Apply gravity to the main projectile
            Projectile.velocity.Y += 0.2f;

            // Add custom dust trail
            int dustId = Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[dustId].velocity *= 0.3f;
            Main.dust[dustId].noGravity = true;
            Main.dust[dustId].scale = 1.0f;

            // Rotate to match velocity direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Destroy the main projectile and spawn dust
            Projectile.Kill();
            for (int i = 0; i < 10; i++)
            {
                Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), oldVelocity.X * 0.5f, oldVelocity.Y * 0.5f, 100, default(Color), 1.5f);
            }
            return false;
        }
    }
}
