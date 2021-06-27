using System;
using System.Collections.Generic;
using Fighter.ScriptableObject;
using UnityEngine;
using System.Linq;
using Fighter.Type;

namespace Fighter.Manager {
    public static class ResourceManager {
        private static readonly Dictionary<ResourceType, List<GameObject>> Resources =
            new Dictionary<ResourceType, List<GameObject>>();

        public static void Initialize() {
            var scriptableObjects = UnityEngine.Resources.LoadAll<UnityEngine.ScriptableObject>("ScriptableObjects/");
            var prefabs = scriptableObjects.Cast<PrefabScriptableObject>();
            foreach (var prefab in prefabs) {
                var type = (ResourceType) Enum.Parse(typeof(ResourceType), prefab.name);
                Resources.Add(type, prefab.data);
            }
        }

        public static GameObject GetPrefab(ResourceType type, int id) {
            try {
                return Resources[type][id];
            }
            catch (Exception e) {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}