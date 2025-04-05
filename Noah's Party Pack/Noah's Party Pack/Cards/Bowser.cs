using Photon.Pun.Simple;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using static CardInfoStat;
using static UnityEngine.Random;


namespace Noah_s_Party_Pack.Cards
{
    class Bowser : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            // Tanky body
            statModifiers.health = 1.5f;              // 50% more health
            statModifiers.sizeMultiplier = 1.4f;      // Slightly bigger
            statModifiers.movementSpeed = 0.5f;       // 30% slower movement
            statModifiers.jump = 1.5f;                // High jump
            statModifiers.gravity = 1.8f;             // Heavy gravity

            // Fire breath style gun
            gun.damage = 0.3f;                        // High single-shot damage
            gun.ammo = 10;                             // Fewer shots (more punchy fireballs)
            gun.spread = 0.25f;                       // Very wide cone (short-range AoE feel)
            gun.projectileColor = new Color(0.85f, 0.1f, 0.1f); // deep fiery red
            gun.projectileSpeed = 3f;                 // Slowish fireballs (don’t travel far)
            gun.bursts = 1;
            gun.numberOfProjectiles = 4;
            gun.damageAfterDistanceMultiplier = 0.1f; // Minimal damage far away
            gun.attackSpeed = 0.6f;                   // Slower rate of fire
            gun.projectileSize = 1.2f;                // Big fireballs
            gun.reloadTime = 2.5f;                    // 2.5 seconds to recharge after emptying
            gun.destroyBulletAfter = 0.05f;           // super short lifespan
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            SkinUtils.SetPlayerColor(player, Color.green);
        }
        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            //Run when the card is removed from the player
        }

        protected override string GetTitle()
        {
            return "Bowser";
        }
        protected override string GetDescription()
        {
            return "Basically what you'd expect if you became Bowser";
        }
        protected override GameObject GetCardArt()
        {
            return null;
        }
        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Rare;
        }
        protected override CardInfoStat[] GetStats()
        {
            return new CardInfoStat[]
            {
                new CardInfoStat() { positive = true, stat = "Health", amount = "+50%" },
                new CardInfoStat() { positive = false, stat = "Move Speed", amount = "-50%" },
                new CardInfoStat() { positive = true, stat = "Jump", amount = "+50%" },
                new CardInfoStat() { positive = true, stat = "Size", amount = "Slightly Larger" },
                new CardInfoStat() { positive = false, stat = "Gravity", amount = "Heavier" },
                new CardInfoStat() { positive = true, stat = "Fire Damage", amount = "High up close" },
                new CardInfoStat() { positive = false, stat = "Range Damage", amount = "Very Weak" },
                new CardInfoStat() { positive = false, stat = "Ammo", amount = "Reduced" },
                new CardInfoStat() { positive = false, stat = "Recharge Breath", amount = "2.5s" }
            };
        }

        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.DestructiveRed;
        }
        public override string GetModName()
        {
            return PartyPack.ModInitials;
        }
    }
}