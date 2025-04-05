using System;
using UnboundLib;
using UnboundLib.Cards;
using UnityEngine;
using static CardInfoStat;

namespace Noah_s_Party_Pack.Cards
{
    class Mario : CustomCard
    {
        public override void SetupCard(CardInfo cardInfo, Gun gun, ApplyCardStats cardStats, CharacterStatModifiers statModifiers, Block block)
        {
            // FIREBALL gun setup
            gun.damage = .25f;
            gun.timeBetweenBullets = 0.20f;
            gun.gravity = 2.0f;
            gun.reflects = 10;
            gun.ammo = 10;
            gun.reloadTime = 3f;
            gun.projectileColor = new Color(0.82f, 0.216f, 0f);
            gun.projectileSize = 1.3f;
            gun.projectileSpeed = 0.25f;
            gun.explodeNearEnemyDamage = 1f;
            gun.explodeNearEnemyRange = 1f;
        }

        public override void OnAddCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // Set Mario’s skin color to white
            SkinUtils.SetPlayerColor(player, new Color(0.91f, 0.91f, 0.91f));
        }

        public override void OnRemoveCard(Player player, Gun gun, GunAmmo gunAmmo, CharacterData data, HealthHandler health, Gravity gravity, Block block, CharacterStatModifiers characterStats)
        {
            // Optionally reset skin color here
        }

        protected override string GetTitle()
        {
            return "Mario";
        }

        protected override string GetDescription()
        {
            return "Become Mario! Bounce fiery fireballs off your foes!";
        }

        protected override GameObject GetCardArt()
        {
            return null; // Optional: insert sprite later
        }

        protected override CardInfo.Rarity GetRarity()
        {
            return CardInfo.Rarity.Common;
        }

        protected override CardInfoStat[] GetStats()
        {
            return new[]
            {
                new CardInfoStat { positive = true,  stat = "Ammo",            amount = "+10 fireballs",     simepleAmount = SimpleAmount.aLotOf },
                new CardInfoStat { positive = true,  stat = "Bounces",         amount = "10x",               simepleAmount = SimpleAmount.Some },
                new CardInfoStat { positive = true,  stat = "Projectile Size", amount = "+30%",              simepleAmount = SimpleAmount.Some },
                new CardInfoStat { positive = false, stat = "Damage",          amount = "-75%",              simepleAmount = SimpleAmount.aLittleBitOf },
                new CardInfoStat { positive = false, stat = "Reload Time",     amount = "+3s",               simepleAmount = SimpleAmount.aLotOf },
                new CardInfoStat { positive = false, stat = "Fire Rate",       amount = "Slow",              simepleAmount = SimpleAmount.aLotOf },
                new CardInfoStat { positive = false, stat = "Projectile Speed",amount = "Very slow",         simepleAmount = SimpleAmount.aLotOf },
                new CardInfoStat { positive = false, stat = "Bullet Gravity",  amount = "Heavy",         simepleAmount = SimpleAmount.aLotOf },
            };
        }


        protected override CardThemeColor.CardThemeColorType GetTheme()
        {
            return CardThemeColor.CardThemeColorType.ColdBlue;
        }

        public override string GetModName()
        {
            return PartyPack.ModInitials;
        }
    }
}
