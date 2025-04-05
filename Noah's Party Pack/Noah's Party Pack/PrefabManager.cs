using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Noah_s_Party_Pack
{
    public class PrefabManager : MonoBehaviour
    {
        public static PrefabManager instance;

        public GameObject minionPrefab;

        void Awake()
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
