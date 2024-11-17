using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Mythos.Content.Buffs;
using Mythos.Content.Projectiles.Minions;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Mythos.Content.Items.Weapons.Summon
{
    internal class SylvaStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.GamepadWholeScreenUseRange[Type] = true;
            ItemID.Sets.LockOnIgnoresCollision[Type] = true;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 80;
            Item.scale = 0.8f;

            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.UseSound = SoundID.Item44;

            Item.DamageType = DamageClass.Summon;
            Item.noMelee = true;
            Item.mana = 16;
            Item.damage = 20;
            Item.knockBack = 1f;

            Item.value = Item.buyPrice(gold: 1);

            Item.shoot = ModContent.ProjectileType<SylvaMinion>();
            Item.buffType = ModContent.BuffType<SylvaMinionBuff>();
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            position = Main.MouseWorld;
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            player.AddBuff(Item.buffType, 2);

            var projectile = Projectile.NewProjectileDirect(source, position, velocity, type, damage, Main.myPlayer);
            projectile.originalDamage = Item.damage;

            return false;
        }
    }
}
