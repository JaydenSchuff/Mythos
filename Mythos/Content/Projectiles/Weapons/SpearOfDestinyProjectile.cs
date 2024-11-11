using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Mythos.Content.Projectiles.Weapons
{ 
	public class SpearOfDestinyProjectile : ModProjectile
	{
		// The Display Name and Tooltip of this item can be edited in the 'Localization/en-US_Mods.Mythos.hjson' file.
		public override void SetDefaults()
		{
			Projectile.width = 70;
            Projectile.height = 50;

            Projectile.scale = 1.6f;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ownerHitCheck = true;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 200;

            Projectile.aiStyle = ProjAIStyleID.ShortSword;
		}

        public override void AI()
        {
            base.AI();

            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2 - MathHelper.PiOver4 * Projectile.spriteDirection;

            int halfProjWidth = Projectile.width / 2;
            int halfProjHeight = Projectile.height / 4;

            DrawOriginOffsetX = 0;
            DrawOffsetX = -((32 / 2) - halfProjWidth);
            DrawOriginOffsetY = -((32 / 4) - halfProjHeight);
        }
    }
}
