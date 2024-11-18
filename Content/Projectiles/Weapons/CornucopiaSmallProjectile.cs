using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Mythos.Content.Dust;

namespace Mythos.Content.Projectiles.Weapons
{

internal class CornucopiaSmallProjectile : ModProjectile
{
    public override void SetDefaults()
    {
        Projectile.width = 18;
        Projectile.height = 18;
        Projectile.scale = 0.6f;

        Projectile.friendly = true;
        Projectile.penetrate = 1;
        Projectile.tileCollide = true;
        Projectile.DamageType = DamageClass.Magic;
        Projectile.ignoreWater = true;
        Projectile.aiStyle = 0;
    }

    public override void AI()
    {
        // Apply gravity
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
        Projectile.Kill();
        for (int i = 0; i < 5; i++)
        {
            Terraria.Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<CornucopiaDust>(), oldVelocity.X * 0.5f, oldVelocity.Y * 0.5f, 100, default(Color), 1.5f);
        }
        return false;
    }
}
}
