using Terraria;
using Terraria.ModLoader;

namespace Mythos.Content.Dust
{
    internal class CornucopiaDust : ModDust
    {
       public override void OnSpawn(Terraria.Dust dust)
        {
            dust.noGravity = true;
            dust.noLight = true;
        }

        public override bool Update(Terraria.Dust dust)
        {
            dust.position += dust.velocity;
            dust.rotation += dust.velocity.X * 0.15f;
            dust.scale *= 0.99f;
            if(dust.scale < 0.3f)
            {
                dust.active = false;
            }

            Lighting.AddLight(dust.position, 0.75f, 0.75f, 0.75f);

            return false;
        }
    }
}