using System.Collections.Generic;
using Fighter.ScriptableObject;
using UnityEngine;
using System.Linq;

namespace Fighter.Manager {
    public static class ResourceManager {
        private static readonly List<UnityEngine.ScriptableObject> Resources = new List<UnityEngine.ScriptableObject>();

        public static void Initialize() {
            var res = UnityEngine.Resources.LoadAll<UnityEngine.ScriptableObject>("ScriptableObjects/");
            Resources.AddRange(res);
        }

        private static T Get<T>() {
            var result = Resources.FirstOrDefault(x => x is T);
            if (result != null && result is T t) {
                return t;
            }

            Debug.LogError($"{typeof(T)} is not exist !");
            return default;
        }

        public static GameObject GetPlayer(int id) {
            var datas = Get<PlayerScriptableObject>();
            var data = datas.players[id];
            if (data == null) {
                Debug.LogError($"Player{id} is not exist !");
                return null;
            }

            return data;
        }
    }
}