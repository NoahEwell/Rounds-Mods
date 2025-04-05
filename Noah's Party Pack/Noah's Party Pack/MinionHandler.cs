using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnboundLib.GameModes;
using UnityEngine;

namespace Noah_s_Party_Pack
{
    public class MinionHandler : MonoBehaviour
    {
        private Player player;

        void Start()
        {
            player = GetComponent<Player>();
            GameModeManager.AddHook(GameModeHooks.HookRoundStart, OnRoundStart);
        }

        private IEnumerator OnRoundStart(IGameModeHandler gm)
        {
            yield return new WaitForSeconds(0.1f);
            SpawnMinions(1);
        }

        public void SpawnMinions(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var spawner = player.transform;
                GameObject minion = Instantiate(PrefabManager.instance.minionPrefab, spawner.position + Vector3.right * i, spawner.rotation);
                minion.GetComponent<SpawnMinion>().Go();
                SkinUtils.SetColorOnGameObject(minion, Color.black);
            }
        }

        void OnDestroy()
        {
            // Clean up
            GameModeManager.RemoveHook(GameModeHooks.HookRoundStart, OnRoundStart);
        }
    }
}
