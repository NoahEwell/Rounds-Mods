using System;
using BepInEx;
using UnboundLib;
using UnboundLib.Cards;
using Noah_s_Party_Pack.Cards;
using HarmonyLib;
using CardChoiceSpawnUniqueCardPatch.CustomCategories;


namespace Noah_s_Party_Pack
{
    // These are the mods required for our mod to work
    [BepInDependency("com.willis.rounds.unbound", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.moddingutils", BepInDependency.DependencyFlags.HardDependency)]
    [BepInDependency("pykess.rounds.plugins.cardchoicespawnuniquecardpatch", BepInDependency.DependencyFlags.HardDependency)]

    [BepInPlugin(ModId, ModName, Version)]

    [BepInProcess("Rounds.exe")]

    public class PartyPack : BaseUnityPlugin
    {
        private const string ModId = "com.exactnoah.rounds.PartyPack";
        private const string ModName = "PartyPack";
        public const string Version = "1.0.0"; 
        public const string ModInitials = "NOAH";

        public static PartyPack MyPartyPack {  get; private set; }

        void Awake()
        {
            var harmony = new Harmony(ModId);
            harmony.PatchAll();
        }
        void Start()
        {
            CustomCard.BuildCard<EvasiveManeuvers>();
            CustomCard.BuildCard<Sun>();
            CustomCard.BuildCard<Slappy>();
            CustomCard.BuildCard<Bunny>();
            CustomCard.BuildCard<Bowser>();
            CustomCard.BuildCard<Delayed>();
            CustomCard.BuildCard<ForcePull>();
            CustomCard.BuildCard<Satellite>();
            CustomCard.BuildCard<Hoho>();
            MyPartyPack = this;
        }
    }
}
