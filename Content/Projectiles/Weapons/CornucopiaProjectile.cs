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
            Projectile.width = 26;  // Adjusted size for the main projectile
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
            // Make the projectile move in the direction of the pla
            
            {
                // Calculate the direction the player is facing
                Vector2 playerToMouse = Main.MouseWorld - Projectile.position; // Direction from the projectile to the mouse
                playerToMouse.Normalize();  // Normalize the vector to get only direction, no speed

                // Set the velocity to move in that direction
                Projectile.velocity = playerToMouse * 10f; // Adjust the '10f' value for projectile speed

                // Spawn the smaller projectiles with slight spread
                for (int i = -1; i <= 1; i++)
                {
                    if (i == 0) continue; // Skip the main projectile, only spawn the smaller ones

                    // Calculate a small spread using rotation
                    float rotation = MathHelper.ToRadians(10) * i; // Adjust angle for arc
                    Vector2 newVelocity = Projectile.velocity.RotatedBy(rotation) * 0.75f; // Make smaller projectiles travel slower

                    // Spawn the smaller projectiles
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), 
                        Projectile.position, newVelocity, 
                        ModContent.ProjectileType<CornucopiaSmallProjectile>(), 
                        Projectile.damage, Projectile.knockBack, 
                        Projectile.owner);
                }

                // Mark as initialized to avoid spawning multiple projectiles every frame
                Projectile.ai[0] = 1;
            }

            // Apply gravity to the main projectile
            Projectile.velocity.Y += 0.2f;  // Adjust gravity strength if needed

            // Add custom dust trail
            int dustId = Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[dustId].velocity *= 0.3f;
            Main.dust[dustId].noGravity = true;
            Main.dust[dustId].scale = 1.0f;

            // Rotate the main projectile to match its movement direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Destroy the main projectile when it collides with tiles
            Projectile.Kill();

            // Spawn custom dust on impact
            for (int i = 0; i < 10; i++)
            {
                Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), oldVelocity.X * 0.5f, oldVelocity.Y * 0.5f, 100, default(Color), 1.5f);
            }

            return false;
        }
    }

    // Smaller CornucopiaProjectile class for the smaller projectiles
    internal class CornucopiaSmallProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 18;  // Smaller size
            Projectile.height = 18;
            Projectile.scale = 0.6f;

            Projectile.friendly = true;
            Projectile.penetrate = 1;  // You can make these projectiles disappear after hitting a target
            Projectile.tileCollide = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.ignoreWater = true;
            Projectile.aiStyle = 0; // Custom AI
        }

        public override void AI()
        {
            // Apply gravity to the smaller projectiles
            Projectile.velocity.Y += 0.2f;

            // Add custom dust trail
            int dustId = Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), 0f, 0f, 100, default(Color), 1.2f);
            Main.dust[dustId].velocity *= 0.3f;
            Main.dust[dustId].noGravity = true;
            Main.dust[dustId].scale = 1.0f;

            // Rotate the smaller projectile to match its movement direction
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            // Destroy the smaller projectile when it collides with tiles
            Projectile.Kill();

            // Spawn custom dust on impact
            for (int i = 0; i < 5; i++)
            {
                Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), oldVelocity.X * 0.5f, oldVelocity.Y * 0.5f, 100, default(Color), 1.5f);
            }

            return false;
        }
    }
}
